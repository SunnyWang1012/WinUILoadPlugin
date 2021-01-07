using Microsoft.UI.Xaml.Controls;
using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        public string Name => "Hello";

        public string Description => "My hello plugin...";

        public UserControl View => new HelloUserControl();

        public int Execute()
        {
            //return 123;

            var provider = new DataProvider.Provider();
            return provider.Execute();
        }

        public UserControl GetView()
        {
            throw new NotImplementedException();
        }
    }
}
