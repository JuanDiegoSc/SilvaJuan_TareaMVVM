namespace AppJuanDiegoSilva_MAUI.Views;

public partial class AllNotesPage_JDS : ContentPage
{
	public AllNotesPage_JDS()
	{
		InitializeComponent();
        BindingContext = new Models.AllNotes_JDS();
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes_JDS)BindingContext).LoadNotes();
    }

    private async void Add_Clicked_JDS(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage_JDS));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note_JDS)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage_JDS)}?{nameof(NotePage_JDS.ItemId)}={note.Filename_JDS}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}