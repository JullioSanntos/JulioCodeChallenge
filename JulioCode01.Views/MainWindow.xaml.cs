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

        //https://stackoverflow.com/questions/24515852/using-adorner-to-show-stretched-overlay-containing-uielements
        //private void Expander_OnExpanded(object sender, RoutedEventArgs e) {
        //    var expander = (sender as Expander)!;
        //    StackPanel overlayPanel = new StackPanel() {
        //    Background = new SolidColorBrush(Color.FromArgb(0x99, 0, 0, 0xFF)),
        //    };

        //    // example content 1
        //    Rectangle overlayChild1 = new Rectangle() {
        //    Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF)),
        //    Margin = new Thickness(10),
        //    Height = 20,
        //    };
        //    overlayPanel.Children.Add(overlayChild1);

        //    // example content 2
        //    Button overlayChild2 = new Button();
        //    overlayChild2.Content = "asdasd";
        //    overlayChild2.Margin = new Thickness(10);
        //    overlayPanel.Children.Add(overlayChild2);

        //    var overlayAdorner = new OverlayAdorner(expander) {Content = overlayPanel };

        //    var adornerLayer = AdornerLayer.GetAdornerLayer(expander);
        //    adornerLayer?.Add(overlayAdorner);
        //}

        //private void Expander_OnCollapsed(object sender, RoutedEventArgs e) {

        //}



    }


}