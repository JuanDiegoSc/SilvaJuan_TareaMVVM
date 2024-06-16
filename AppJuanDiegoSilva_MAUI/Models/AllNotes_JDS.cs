using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJuanDiegoSilva_MAUI.Models
{
    public class AllNotes_JDS
    {
        public ObservableCollection<Note_JDS> Notes { get; set; } = new ObservableCollection<Note_JDS>();

        public AllNotes_JDS() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note_JDS> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Note_JDS()
                                        {
                                            Filename_JDS = filename,
                                            Text_JDS = File.ReadAllText(filename),
                                            Date_JDS = File.GetLastWriteTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date_JDS);

            // Add each note into the ObservableCollection
            foreach (Note_JDS note in notes)
                Notes.Add(note);
        }
    }
}
