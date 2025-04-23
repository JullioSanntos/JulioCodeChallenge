using System.ComponentModel;
using JulioCode06.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case nameof(ViewModel.SelectedInvalidTrade):
                    if (ViewModel.SelectedInvalidTrade != null) {
                        this.TradesGrid.ScrollIntoView(ViewModel.SelectedInvalidTrade);
                    }
                    break;
            };
        }
    }
}