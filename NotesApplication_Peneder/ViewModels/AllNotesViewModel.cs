using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class AllNotesViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly SettingsViewModel _settings;
        private readonly INavigationService _navigationService;

        public AllNotesViewModel(IDataService dataService, SettingsViewModel settings, 
            INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
            this._settings = settings;

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SearchString)
                )
                {
                    LoadData();
                }
            };

            
            LoadData();
        }

        public async void LoadData()
        {
            var notes = await _dataService.GetAllNotes();
            notes = _settings.IsSortAscending
                        ? notes.OrderBy(n => n.Date)
                        : notes.OrderByDescending(n => n.Date);
            notes = notes.Where(n => n.Text.ToLower().Contains(SearchString)).Take(_settings.MaxNotes);
            
            Notes = new ObservableCollection<Note>(notes);
        }

        public async void DeleteNote(Note note)
        {
            await _dataService.DeleteNote(note);
            LoadData();
        }
        

        public void NavigateToEditNotePage()
        {
            _navigationService.NavigateTo("EditNote", SelectedNote);
            LoadData();
        }

        public Note SelectedNote { get; set; }

        public string SearchString { get; set; } = "";

        public ObservableCollection<Note> Notes { get; set; }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}