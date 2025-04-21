using System.Windows;
using JulioCode06.ViewModels;

namespace JulioCode03.Views {
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window {

        public MainViewModel ViewModel { get; set; }


        public MainView(MainViewModel viewModel) {
            ViewModel = viewModel;
            InitializeComponent();
        }


    }
}
