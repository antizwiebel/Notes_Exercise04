using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class CreateNewNoteViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IDataService _dataService;

        private readonly IDialogService _dialogService;

        private Geolocator _geolocator;

        public CreateNewNoteViewModel(INavigationService navigationService,
                                      IDataService dataService,
                                      IDialogService dialogService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
            this._dialogService = dialogService;
            _geolocator= new Geolocator();
            Text = "";
            Title = "";
            Time = DateTime.Now;
            DispatcherTimer time = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            time.Tick += new EventHandler<object>(time_tick);
            time.Start();
        }

        public DateTime Time { get; set; }


        public async void AddNote()
        {
            await GetCurrentLocation();
            await _dataService.AddNote(new Note(Text, Title, Geopoint.Position.Latitude, Geopoint.Position.Longitude));
            Text = string.Empty;
        }

        private async 
        Task
GetCurrentLocation()
        {
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Allowed:

                    var geolocator = new Geolocator();
                    var geopositon = await geolocator.GetGeopositionAsync();
                    Geopoint = geopositon.Coordinate.Point;
                    
                    break;
                case GeolocationAccessStatus.Unspecified:
                case GeolocationAccessStatus.Denied:
                    break;
            }
        }

        public Geopoint Geopoint { get; set; }

        private void time_tick(object sender, object e)
        {
            Time = DateTime.Now;
        }

        public bool CanAddNote => !string.IsNullOrEmpty(Text);
        public string Text { get; set; }

        public string Title { get; set; }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}
