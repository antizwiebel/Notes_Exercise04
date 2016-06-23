using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesExercise03_Peneder.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadNotesPage : Page
    {
        public ReadNotesPage()
        {
            this.InitializeComponent();
        }


        public AllNotesViewModel ViewModel => DataContext as AllNotesViewModel;

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateBack();
        }


       

        private void UIElement_OnHolding(object sender, DoubleTappedRoutedEventArgs doubleTappedRoutedEventArgs)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }

        private void FlyoutDeleteNote
            (object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteNote((Note)ListViewNotes.SelectedItem);
        }

        private void FlyoutEditNote(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToEditNotePage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();
            base.OnNavigatedTo(e);
        }
    }
    }

