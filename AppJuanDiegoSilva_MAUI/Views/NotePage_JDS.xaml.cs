namespace AppJuanDiegoSilva_MAUI.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage_JDS : ContentPage
{

    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage_JDS()
	{
		InitializeComponent();


        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked_JDS(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note_JDS note)
            File.WriteAllText(note.Filename_JDS, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked_JDS(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note_JDS note)
        {
            // Delete the file.
            if (File.Exists(note.Filename_JDS))
                File.Delete(note.Filename_JDS);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void LoadNote(string fileName)
    {
        Models.Note_JDS noteModel = new Models.Note_JDS();
        noteModel.Filename_JDS = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date_JDS = File.GetCreationTime(fileName);
            noteModel.Text_JDS = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }
}