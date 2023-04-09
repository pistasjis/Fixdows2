using System.Diagnostics;
using Fixdows2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Fixdows2.Views;

public sealed partial class AboutPage : Page
{
    public AboutViewModel ViewModel
    {
        get;
    }

    public AboutPage()
    {
        ViewModel = App.GetService<AboutViewModel>();
        this.DataContext = this;
        InitializeComponent();
    }

    public string Version
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
        DonationDialog donationDialog = new DonationDialog();
        donationDialog.XamlRoot = XamlRoot;
        await donationDialog.ShowAsync();
    }
}
