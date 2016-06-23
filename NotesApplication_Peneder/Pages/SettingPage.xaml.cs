using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesExercise03_Peneder.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
        }
        public SettingsViewModel ViewModel => DataContext as SettingsViewModel;
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
              ViewModel.NavigateBack();
        }
    }
    
}
