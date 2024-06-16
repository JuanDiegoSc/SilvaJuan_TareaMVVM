using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppJuanDiegoSilva_MAUI.ViewModels
{
    public class NotesViewModel_JDS : IQueryAttributable
    {
        public ObservableCollection<ViewModels.NoteViewModel_JDS> AllNotes_JDS { get; }
        public ICommand NewCommand_JDS { get; }
        public ICommand SelectNoteCommand_JDS { get; }

        public NotesViewModel_JDS()
        {
            AllNotes_JDS = new ObservableCollection<NoteViewModel_JDS>(Models.Note_JDS.LoadAll().Select(n => new NoteViewModel_JDS(n)));
            NewCommand_JDS = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand_JDS = new AsyncRelayCommand<NoteViewModel_JDS>(SelectNoteAsync);
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.NotePage_JDS));
        }

        private async Task SelectNoteAsync(NoteViewModel_JDS note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.NotePage_JDS)}?load={note.Identifier_JDS}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NoteViewModel_JDS matchedNote = AllNotes_JDS.Where((n) => n.Identifier_JDS == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes_JDS.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NoteViewModel_JDS matchedNote = AllNotes_JDS.Where((n) => n.Identifier_JDS == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes_JDS.Move(AllNotes_JDS.IndexOf(matchedNote), 0);
                }
                    
                // If note isn't found, it's new; add it.
                else
                    AllNotes_JDS.Insert(0, new NoteViewModel_JDS(Models.Note_JDS.Load(noteId)));
            }
        }


    }
}
