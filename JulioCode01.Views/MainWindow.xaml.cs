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
            this.Loaded += MainWindow_Loaded;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            var gridItemsSourceDP = DependencyPropertyDescriptor
                .FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            
            gridItemsSourceDP.AddValueChanged(TradesGrid, TradesGridItemsSourceChanged);
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case nameof(ViewModel.IsLoading):
                    break;
            };
        }


        public void TradesGridItemsSourceChanged(object? sender, EventArgs e) {
            //var count = (((DataGrid)sender!).ItemsSource as List<JulioCode12.Common.Trade>)?.Count;
            var itemSource = this.TradesGrid.ItemsSource as List<JulioCode12.Common.Trade>;
            if (itemSource == null) { return; }
            ViewModel.RowIndexTradeIdDict.Clear();
            var ix = 0;
            foreach (var trade in itemSource) {
                ViewModel.RowIndexTradeIdDict.Add(trade.TradeId, ix);
                ix++;
            }
        }

    }


}