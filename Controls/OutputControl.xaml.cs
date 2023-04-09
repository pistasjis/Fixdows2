using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.NetworkOperators;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fixdows2.Controls
{
    public sealed partial class OutputControl : UserControl
    {
        public OutputControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.XamlRoot = XamlRoot;
        }

        public string? Output
        {
            get { return (string)GetValue(OutputProperty); }
            set { SetValue(OutputProperty, value); }
        }

        DependencyProperty OutputProperty = DependencyProperty.Register(
            nameof(Output), 
            typeof(string),
            typeof(OutputControl),
            new PropertyMetadata((null)));
    }
}
