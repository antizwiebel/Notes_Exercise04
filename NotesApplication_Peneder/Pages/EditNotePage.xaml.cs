using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesExercise03_Peneder.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditNotePage : Page
    {
        public EditNotePage()
        {
            this.InitializeComponent();
        }
        public EditNoteViewModel ViewModel => DataContext as EditNoteViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OldNote = e.Parameter as Note;
            ViewModel.Text = ViewModel.OldNote.Text;
            ViewModel.PointsOfInterest.Add( new PointOfInterest()
            {
                Description = ViewModel.OldNote.Text,
                Geopoint = ViewModel.OldNote.Location
            });
            base.OnNavigatedTo(e);
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            
            ViewModel.NavigateBack();
        }
    }
}
