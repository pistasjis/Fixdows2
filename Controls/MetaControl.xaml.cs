using Fixdows2.Views;
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

namespace Fixdows2.Controls
{
    public sealed partial class MetaControl : UserControl
    {
        public MetaControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public static string Version
        {
            get
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        public void OpenGitHub(object sender, RoutedEventArgs e)
        {
            // So we meet again.
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://github.com/Odyssey346/Fixdows2") { UseShellExecute = true });
        }

        private async void Donation_Click(object sender, RoutedEventArgs e)
        {
            DonationDialog donationDialog = new()
            {
                XamlRoot = XamlRoot
            };
            ContentDialogResult result = await donationDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Process.Start(new ProcessStartInfo("https://odyssey346.dev/about#donate") { UseShellExecute = true });
            }
        }
    }
}
