using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class SettingsViewModel :ViewModelBase
    {
        private readonly IStorageService _storageService;
        private readonly IDataService _iDataService;

        private readonly INavigationService _navigationService;

        public SettingsViewModel(IStorageService storageService, INavigationService navigationService,
            IDataService dataService)
        {
            this._navigationService = navigationService;
            this._storageService = storageService;
            this._iDataService = dataService;

        }

        public int MaxNotes { get; set; } = 10;

        public bool IsSortAscending { get; set; }




        public void Save()
        {
            _storageService.Write(nameof(MaxNotes), MaxNotes);
            _storageService.Write(nameof(IsSortAscending), IsSortAscending);
        }

        public void Load()
        {
            MaxNotes = _storageService.Read<int>(nameof(MaxNotes), 15);
            IsSortAscending = _storageService.Read<bool>(nameof(IsSortAscending), true);
            
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}