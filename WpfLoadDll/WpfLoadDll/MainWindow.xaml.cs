using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLoadDll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            var dirInfo = Directory.GetParent(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName);
            var path = System.IO.Path.Combine(dirInfo.FullName, @"Plugins");

            string[] pluginFiles = Directory.GetFiles(path, "*.dll");

            foreach(var pluginFile in pluginFiles)
            {
                var assembly = Assembly.LoadFrom(pluginFile);

                foreach (var type in assembly.GetExportedTypes())
                {
                    if (typeof(PluginBase.ICommand).IsAssignableFrom(type))
                    {
                        var cmd = Activator.CreateInstance(type) as PluginBase.ICommand;
                        var name = cmd.Name;
                        var ret = cmd.Execute();
                        var view = cmd.View;

                        MyContentControl.Content = view;

                        return;  
                    }
                }

            }


        }

        /*
         ipi = (
    // From each file in the files.
    from file in pluginFiles
    // Load the assembly.
    let asm = Assembly.LoadFile(file)
    // For every type in the assembly that is visible outside of
    // the assembly.
    from type in asm.GetExportedTypes()
    // Where the type implements the interface.
    where typeof(IPlugin).IsAssignableFrom(type)
    // Create the instance.
    select (IPlugin) Activator.CreateInstance(type)
         */

    }
}
