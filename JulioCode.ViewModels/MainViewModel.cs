using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using JulioCode12.Common;
using JulioCode12.Common.WPF;

namespace JulioCode06.ViewModels; 
public class MainViewModel : SetPropertyBase {

    #region properties
    #region LoadTradeCommand
    public ICommand LoadTradeCommand => new RelayCommand(async _ => await LoadTrades());
    #endregion LoadTradeCommand

    #region LoadTradesService
    public LoadTradesService LoadTradesService { get; init; }
    #endregion LoadTradesService

    #region BusyIndicatorVisibility
    private string _busyIndicatorVisibility = "Collapsed";
    public string BusyIndicatorVisibility {
        get => _busyIndicatorVisibility;
        set => SetProperty(ref _busyIndicatorVisibility, value);
    }
    #endregion BusyIndicatorVisibility

    #region TradesList
    private List<Trade>? _tradesList;
    public List<Trade> TradesList {
        get { return _tradesList ??= []; }
        set => SetProperty(ref _tradesList, value);
    }
    #endregion TradesList

    #region TradesView
    private List<Trade>? _tradesView;

    public List<Trade> TradesView {
        get { return _tradesView ??= []; }
        set => SetProperty(ref _tradesView, value);
    }
    #endregion TradesView

    #region SelectedTrade
    private Trade? _selectedTrade;
    public Trade? SelectedTrade {
        get => _selectedTrade;
        set => SetProperty(ref _selectedTrade, value);
    }
    #endregion SelectedTrade

    #region CurrencyListFilter
    private List<string>? _currencyListFilter = new List<string>();
    public List<string> CurrencyListFilter {
        get => _currencyListFilter!;
        set {
            value.Insert(0, SelectionCleared);
            SetProperty(ref _currencyListFilter, value);
        }
    }

    #region SelectedFilter
    const string SelectionCleared = "--- clear ---";
    private string _selectedFilter = string.Empty;
    public string SelectedFilter {
        get => _selectedFilter!;
        set => SetProperty(ref _selectedFilter, value);
    }
    #endregion SelectedFilter
    #endregion CurrencyListFilter

    #region IsLoading
    private bool _isLoading;
    public bool IsLoading {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }
    #endregion IsLoading

    #region InvalidTradeMessage
    private ObservableCollection<Trade> _invalidTrades = new ObservableCollection<Trade>();
    public ObservableCollection<Trade> InvalidTrades {
        get => _invalidTrades;
        set => SetProperty(ref _invalidTrades!, value);
    }
    #endregion InvalidTradeMessage

    #region HasTrades
    public bool HasTrades => TradesList.Count != 0;
    #endregion HasTrades

    #region SelectedInvalidTrade
    private Trade? _selectedInvalidTrade;
    public Trade? SelectedInvalidTrade {
        get => _selectedInvalidTrade;
        set => SetProperty(ref _selectedInvalidTrade, value);
    }
    #endregion SelectedInvalidTrade

    #endregion properties

    #region constructors
    public MainViewModel(LoadTradesService loadTradesService) {
        LoadTradesService = loadTradesService;
        this.PropertyChanged += MainViewModel_PropertyChanged;
    }

    private void MainViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {
        switch (e.PropertyName) {
            case nameof(TradesList):
                TradesView = TradesList;
                CurrencyListFilter = TradesList.GroupBy(t => t.Currency)
                    .Select(g => g.Key).OrderBy(c => c).ToList();

                RaisePropertyChanged(nameof(HasTrades));
                break;
            case nameof(SelectedFilter):
                if (SelectedFilter != SelectionCleared) {
                    TradesView = TradesList.Where(t => t.Currency == SelectedFilter).ToList();
                }
                else { TradesView = TradesList; }
                break;
            case (nameof(TradesView)):
                InvalidTrades = new ObservableCollection<Trade>(
                    TradesView.Where(t => t.IsValid == false).Select(tr => tr).ToList<Trade>()
                );
                break;
            case nameof(SelectedInvalidTrade):
                if (SelectedInvalidTrade != null) { SelectedTrade = SelectedInvalidTrade; }
                break;
        }
    }
    #endregion constructors

    #region methods
    public async Task LoadTrades() {
        BusyIndicatorVisibility = "Visible";
        IsLoading = true;
        _tradesList = null;
        RaisePropertyChanged(nameof(TradesList));
        TradesList = await LoadTradesService.GetTradesAsync();
        IsLoading = false;
        BusyIndicatorVisibility = "Collapsed";

        return;
    }
    #endregion methods

}
