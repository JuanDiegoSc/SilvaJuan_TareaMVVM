namespace AppJuanDiegoSilva_MAUI.Views;

public partial class AboutPage_JDS : ContentPage
{
	public AboutPage_JDS()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked_JDS(object sender, EventArgs e)
    {
        if (BindingContext is Models.About_JDS about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl_JDS);
        }
    }

}