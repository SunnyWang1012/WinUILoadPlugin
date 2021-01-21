using PluginBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        private static UserControl view = new HelloUserControl();

        public string Name => "I am HelloPlugin...";

        public UserControl View => view;

        public int Execute()
        {
            return 123;
        }
    }
}
