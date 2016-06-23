using Windows.UI.Xaml.Controls;
using NotesExercise03_Peneder.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotesExercise03_Peneder.Pages
{
    using NotesExercise03_Peneder.ViewModels;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel => DataContext as MainViewModel;
    }
}
