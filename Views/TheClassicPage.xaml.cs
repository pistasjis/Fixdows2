using Microsoft.UI.Xaml.Controls;
using Fixdows2.ViewModels;
using System.Diagnostics;
using RunProcessAsTask;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fixdows2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TheClassicPage : Page
    {
        public ClassicViewModel ViewModel
        {
            get;
        }

        public TheClassicPage()
        {
            ViewModel = App.GetService<ClassicViewModel>();
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        { 
            Output.Output = "Note: due to .NET limitations, we cannot get the output of commands executed as admin.\nStarting DISM /Online /Cleanup-Image /RestoreHealth...";
            // execute dism command
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c dism /online /cleanup-image /restorehealth",
                UseShellExecute = true,
                Verb = "runas",
            };

            var p = Process.Start(processStartInfo);

            await p.WaitForExitAsync();

            // display output
            Output.Output += " done\n";

            // we are done with dism, now we need to run sfc
            
            Output.Output += "Starting sfc /scannow...";
            // execute sfc command
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c sfc /scannow",
                UseShellExecute = true,
                Verb = "runas"
            };
            var p2 = Process.Start(startInfo);
            await p2.WaitForExitAsync();
         

            // display output
            Output.Output += " done\n";

            // we're all done :)
            Output.Output += "Done! If sfc was way too fast, it is possible you have to restart your computer and try again, due to pending repairs.";
        }
    }
}
