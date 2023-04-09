using Microsoft.UI.Xaml.Controls;
using Fixdows2.ViewModels;
using System.Diagnostics;
using RunProcessAsTask;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fixdows2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MSResetPage : Page
    {
        public MSResetViewModel ViewModel
        {
            get;
        }

        public MSResetPage()
        {
            ViewModel = App.GetService<MSResetViewModel>();
            this.InitializeComponent();
            this.DataContext = this;
        }

        private async Task RunMSResetCommand()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wsreset.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

            await ProcessEx.RunAsync(processStartInfo);
        }

        private async void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wsreset.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

            var process = Process.Start(processStartInfo);

            await process.WaitForExitAsync();

            // set Output text
            // wsreset doesn't output so we'll just set output to this
            // sad
            Output.Output = "Microsoft Store has been reset.";
        }
    }
}
