using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace AppJuanDiegoSilva_MAUI.ViewModels
{
    public class NoteViewModel_JDS : ObservableObject, IQueryAttributable
    {
        private Models.Note_JDS _noteJDS;

        public string? Text_JDS
        {
            get => _noteJDS.Text_JDS;
            set
            {
                if (_noteJDS.Text_JDS != value)
                {
                    _noteJDS.Text_JDS = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date_JDS => _noteJDS.Date_JDS;

        public string? Identifier_JDS => _noteJDS.Filename_JDS;

        public ICommand? SaveCommand_JDS { get; private set; }
        public ICommand? DeleteCommand_JDS { get; private set; }


        public NoteViewModel_JDS()
        {
            _noteJDS = new Models.Note_JDS();
            SaveCommand_JDS = new AsyncRelayCommand(Save_JDS);
            DeleteCommand_JDS = new AsyncRelayCommand(Delete_JDS);
        }

        public NoteViewModel_JDS(Models.Note_JDS note)
        {
            _noteJDS = note;
            SaveCommand_JDS = new AsyncRelayCommand(Save_JDS);
            DeleteCommand_JDS = new AsyncRelayCommand(Delete_JDS);
        }


        private async Task Save_JDS()
        {
            _noteJDS.Date_JDS = DateTime.Now;
            _noteJDS.Save();
            await Shell.Current.GoToAsync($"..?saved={_noteJDS.Filename_JDS}");
        }

        private async Task Delete_JDS()
        {
            _noteJDS.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_noteJDS.Filename_JDS}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _noteJDS = Models.Note_JDS.Load(query["load"].ToString());
                RefreshProperties();
            }
        }
        public void Reload()
        {
            _noteJDS = Models.Note_JDS.Load(_noteJDS.Filename_JDS);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date_JDS));
        }
    }
}
