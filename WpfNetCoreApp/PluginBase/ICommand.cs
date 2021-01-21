using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PluginBase
{
    public interface ICommand
    {
        string Name { get; }
        UserControl View { get; }
        int Execute();
    }
}
