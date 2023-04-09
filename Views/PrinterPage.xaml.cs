using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fixdows2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrinterPage : Page
    {
        public PrinterPage()
        {
            this.InitializeComponent();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Output.Output = "Stopping Print Spooler Service...";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c net stop spooler",
                UseShellExecute = true,
                Verb = "runas"
            };
            var p = Process.Start(startInfo);
            await p.WaitForExitAsync();
            Output.Output += "Done!\n";

            Output.Output += "Deleting Print Spooler Files...";
            startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c del /f /s /q %systemroot%\\system32\\spool\\printers",
                UseShellExecute = true,
                Verb = "runas"
            };
            Output.Output += "Done!\n";

            Output.Output += "Starting Print Spooler Service...";
            startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c net start spooler",
                UseShellExecute = true,
                Verb = "runas"
            };
            p = Process.Start(startInfo);
            await p.WaitForExitAsync();
            Output.Output += "Done!\n";

            Output.Output += "Note that you may need to restart your computer for the changes to take effect.";
        }
    }
}
