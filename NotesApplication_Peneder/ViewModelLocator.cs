using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using NotesExercise03_Peneder.Pages;
using NotesExercise03_Peneder.Services;
using NotesExercise03_Peneder.ViewModels;

namespace NotesExercise03_Peneder
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CreateNewNoteViewModel>();
            SimpleIoc.Default.Register<EditNoteViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<NoteOverviewViewModel>();
            SimpleIoc.Default.Register<AllNotesViewModel>();
            SimpleIoc.Default.Register(RegisterNavigationService);

            SimpleIoc.Default.Register<IStorageService, LocalStorageService>();
            SimpleIoc.Default.Register<IDataService, CloudDataService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            //SimpleIoc.Default.Register<IDataService, DataService>();

        }
        private static INavigationService RegisterNavigationService()
        {
            var service = new NavigationService();
            service.Configure("NewNote", typeof(NewNotePage));
            service.Configure("ReadNote", typeof(ReadNotesPage));
            service.Configure("Settings", typeof(SettingPage));
            service.Configure("EditNote", typeof(EditNotePage));
            service.Configure("NoteOverview", typeof(NoteOverview));

            return service;
        }
        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
        public AllNotesViewModel AllNotesViewModel => ServiceLocator.Current.GetInstance<AllNotesViewModel>();
        public EditNoteViewModel EditNoteViewModel  => ServiceLocator.Current.GetInstance<EditNoteViewModel>();
        public CreateNewNoteViewModel CreateNewNoteViewModel => ServiceLocator.Current.GetInstance<CreateNewNoteViewModel>();
        public NoteOverviewViewModel NoteOverviewViewModel => ServiceLocator.Current.GetInstance<NoteOverviewViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();



    }
}