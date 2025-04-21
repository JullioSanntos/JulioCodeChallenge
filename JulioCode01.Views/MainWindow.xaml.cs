using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JulioCode06.ViewModels;

namespace JulioCode01.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainViewModel ViewModel { get; internal set; }
        public MainWindow(MainViewModel viewModel) {
            InitializeComponent();
            ViewModel = viewModel;
            this.DataContext = viewModel;
        }
    }
}