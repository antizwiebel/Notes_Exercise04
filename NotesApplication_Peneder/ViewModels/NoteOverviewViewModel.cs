using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class NoteOverviewViewModel:ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly SettingsViewModel _settings;
        private readonly INavigationService _navigationService;

        private Geolocator _geolocator;

        public NoteOverviewViewModel(IDataService dataService, SettingsViewModel settings,
            INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
            this._settings = settings;
            _geolocator = new Geolocator();

            LoadData();
        }
       
        public ObservableCollection<Note> Notes { get; set; }


        public string Token => "Cn3mkPnfpuVVQqZYmAK2~C_IlH4yEc80LpOd6svw0YQ~AgCNR4lZOhns-PyXfl_gOeSbsFKLJKrWbgQ5tQOS4WiSgDPrhcVtLauRNmJZmUTd";

        public double Zoomlevel { get; set; } = 5;


        public ObservableCollection<PointOfInterest> PointsOfInterest { get; private set; } = new ObservableCollection<PointOfInterest>();

        public async void LoadData()
        {
            
            var notes = await _dataService.GetAllNotes();
            
            Notes = new ObservableCollection<Note>(notes);
            if(Notes.Count ==0 ) return;
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Allowed:
                    foreach (var note in Notes)
                    {
                        if (note.Location != null)
                        {
                            PointsOfInterest.Add(
                                new PointOfInterest
                                {
                                    Description = new string(note.Text.Take(10).ToArray()),
                                    Geopoint = new Geopoint(new BasicGeoposition
                                    {
                                        Latitude = note.Location.Position.Latitude,
                                        Longitude = note.Location.Position.Longitude,
                                    })
                                });
                        }
                    }
                    break;
            }
            ZoomToFit();
                Center = PointsOfInterest[0].Geopoint;
            Zoomlevel = 15;
        }

        public Geopoint Center { get; set; } = new Geopoint(new BasicGeoposition() { Latitude = 20.0, Longitude = 10.0 });

        public void NavigateToEditNotePage(string description)
        {
            var notes= Notes.Where(n => n.Text.ToLower().Contains(description)).Take(1);
            
            _navigationService.NavigateTo("EditNote",notes.First() );
        }

        private void ZoomToFit()
        {
            Messenger.Default.Send("zoom");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }


    }
    public class PointOfInterest
    {
        public string Description { get; set; }

        public Geopoint Geopoint { get; set; }

    }
}