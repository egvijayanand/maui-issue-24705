using System.Reflection;

namespace HwvApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            versionLabel.Text = $".NET MAUI ver. {version?[..version.IndexOf('+')]}";
        }

        private void OnMessageChanged(object sender, TextChangedEventArgs e)
        {
            send.IsEnabled = message.Text.Trim().Length > 0;
        }

        private void OnSendClicked(object sender, EventArgs e)
        {
            hwv.SendRawMessage(message.Text);
            message.Text = string.Empty;
            message.Focus();
        }

        private async void OnRawMessageReceived(object sender, HybridWebViewRawMessageReceivedEventArgs e)
        {
            await DisplayAlert("Raw Message Received", e.Message, "OK");
        }
    }
}
