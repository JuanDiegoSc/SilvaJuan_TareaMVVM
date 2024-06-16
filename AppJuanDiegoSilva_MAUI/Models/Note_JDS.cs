using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AppJuanDiegoSilva_MAUI.Models
{
    public class Note_JDS
    {
        public string? Filename_JDS { get; set; }
        public string? Text_JDS { get; set; }
        public DateTime Date_JDS { get; set; }

        public Note_JDS()
        {
            Filename_JDS = $"{Path.GetRandomFileName()}.notes.txt";
            Date_JDS = DateTime.Now;
            Text_JDS = "";
        }

        public void Save() =>
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename_JDS), Text_JDS);

        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename_JDS));


        public static Note_JDS Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);

            return
                new()
                {
                    Filename_JDS = Path.GetFileName(filename),
                    Text_JDS = File.ReadAllText(filename),
                    Date_JDS = File.GetLastWriteTime(filename)
                };
        }


        public static IEnumerable<Note_JDS> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")

                    // Each file name is used to load a note
                    .Select(filename => Note_JDS.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(note => note.Date_JDS);
        }

    }
    
}
