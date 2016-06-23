using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesExercise03_Peneder.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewNotePage : Page
    {
        public NewNotePage()
        {
            InitializeComponent();
        }
        public CreateNewNoteViewModel ViewModel => DataContext as CreateNewNoteViewModel;
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxNewNote.Text))
            {

                var dlg = new MessageDialog("Are you sure you want to go back?");
                dlg.Commands.Add(new UICommand("Yes", null, "YES"));
                dlg.Commands.Add(new UICommand("No", null, "NO"));
                var op = await dlg.ShowAsync();

                if ((string) op.Id == "YES")
                {
                    ViewModel.NavigateBack();
                }
            }
            else
            {
                ViewModel.NavigateBack();
            }
        }
    }
}
