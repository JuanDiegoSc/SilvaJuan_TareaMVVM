namespace AppJuanDiegoSilva_MAUI.Views;

public partial class AllNotesPage_JDS : ContentPage
{
	public AllNotesPage_JDS()
	{
		InitializeComponent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}