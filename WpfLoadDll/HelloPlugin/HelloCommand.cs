using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        public string Name => "I am Hello Plugin...";

        public UserControl View => new MyUserControl();

        public int Execute()
        {
            var provider = new DataProvider.Provider();
            var value = provider.GetValue();
            return value;
        }
    }
}
