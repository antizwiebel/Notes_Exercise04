using System;
using System.Collections.ObjectModel;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class EditNoteViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IDataService _dataService;

        private readonly IDialogService _dialogService;

        public EditNoteViewModel(INavigationService navigationService,
                                      IDataService dataService, IDialogService dialogService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
            this._dialogService = dialogService;
           
        }


        public ObservableCollection<PointOfInterest> PointsOfInterest { get; private set; } = new ObservableCollection<PointOfInterest>();


        public void AddNote()
        {
            //Old Note is discarded and a new Note with the time of the last Edit is saved
            _dataService.AddNote(new Note(Text, Title, OldNote.Latitude,OldNote.Longitude));
            _dataService.DeleteNote(OldNote);
            _navigationService.GoBack();
        }

        public string Title { get; set; }

        public string Token => "Cn3mkPnfpuVVQqZYmAK2~C_IlH4yEc80LpOd6svw0YQ~AgCNR4lZOhns-PyXfl_gOeSbsFKLJKrWbgQ5tQOS4WiSgDPrhcVtLauRNmJZmUTd";


        public string Text { get; set; }

        public Note OldNote { get; set; }
    
        public bool CanEditNote => Text!=OldNote.Text;

        public async void NavigateBack()
        {
            if (Text != OldNote.Text)
            {
                await _dialogService.ShowMessage(
                    "Are you sure you want to go back?",
                    "Warning",
                    "Yes",
                    "No",
                    isGoBack =>
                    {
                        if (isGoBack)
                        {
                            _navigationService.GoBack();
                        }
                    });
            }
            else
            {
                _navigationService.GoBack();
            }
        }
    }

}