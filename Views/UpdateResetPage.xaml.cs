using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fixdows2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateResetPage : Page
    {
        public UpdateResetPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public string currentDir = Directory.GetCurrentDirectory();

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Execute Assets/Scripts/wu.bat and wait for it to finish.

            // get current directory
            string currentDir = Directory.GetCurrentDirectory();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c" + currentDir + "Assets/Scripts/wu.bat",
                UseShellExecute = false,
                Verb = "runas",
            };
            
            var p = Process.Start(startInfo);
            await p.WaitForExitAsync();
            
            // Display output
            Output.Output += " done\n";
        }
    }
}
