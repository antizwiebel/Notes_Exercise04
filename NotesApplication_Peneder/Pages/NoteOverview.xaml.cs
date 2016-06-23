using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesExercise03_Peneder.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteOverview : Page
    {
        public NoteOverview()
        {
            this.InitializeComponent();

            Messenger.Default.Register<string>(this, Zoom);

        }

        private async void Zoom(string message)
        {

            if (message != "zoom") return;

            var box = GeoboundingBox.TryCompute(ViewModel.PointsOfInterest.Select(poi => poi.Geopoint.Position));
            await this.MapControl.TrySetViewBoundsAsync(box, new Thickness(10), MapAnimationKind.Linear);
        }

        public NoteOverviewViewModel ViewModel => DataContext as NoteOverviewViewModel;


        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateBack();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();
            base.OnNavigatedTo(e);
        }
        private void PushPin_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock txt =(TextBlock) e.OriginalSource;
            ViewModel.NavigateToEditNotePage(txt.Text);
        }
    }
}
