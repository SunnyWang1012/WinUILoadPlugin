﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
