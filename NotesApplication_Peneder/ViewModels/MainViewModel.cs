using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Pages;

namespace NotesExercise03_Peneder.ViewModels
{


    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            
            
        }


        public void NavigateToEditNotePage()
        {
            _navigationService.NavigateTo("EditNote");
        }

        public void NavigateToNewNotePage()
        {
            _navigationService.NavigateTo("NewNote");
        }

        public void NavigateToReadNotePage()
        {
            _navigationService.NavigateTo("ReadNote");
        }
      
        public void NavigateToSettingsPage()
        {
            _navigationService.NavigateTo("Settings");
        }
        public void NavigateToNoteOverviewPage()
        {
            _navigationService.NavigateTo("NoteOverview");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}