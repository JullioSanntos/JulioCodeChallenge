using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using JulioCode12.Common;
using JulioCode12.Common.WPF;

namespace JulioCode06.ViewModels; 
public class MainViewModel : SetPropertyBase {
    public ICommand LoadTradeCommand => new RelayCommand(async _ => await LoadTrades());

    public LoadTradesService LoadTradesService { get; init; }

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

    #region TradesList
    private List<Trade>? _tradesView;

    public List<Trade> TradesView {
        get { return _tradesView ??= []; }
        set => SetProperty(ref _tradesView, value);
    }
    #endregion TradesList

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

    #region InvalidTrades
    private ObservableCollection<string> _invalidTrades;
    public ObservableCollection<string> InvalidTrades {
        get => _invalidTrades;
        set => SetProperty(ref _invalidTrades, value);
    }
    #endregion InvalidTrades

    #region constructor
    public MainViewModel(LoadTradesService loadTradesService) {
        LoadTradesService = loadTradesService;
        this.PropertyChanged += MainViewModel_PropertyChanged;
    }

    private void MainViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {
        switch (e.PropertyName) {
            case nameof(TradesList):
                TradesView = TradesList;
                CurrencyListFilter = TradesList.GroupBy(t => t.Currency).Select(g => g.Key).ToList();
                InvalidTrades = new ObservableCollection<string>(
                    TradesList.Where(t => t.IsValid == false).Select(t => t.InvalidTrades).ToList()
                    );

                break;
            case nameof(SelectedFilter):
                if (SelectedFilter != SelectionCleared) {
                    TradesView = TradesList.Where(t => t.Currency == SelectedFilter).ToList();
                }
                else { TradesView = TradesList; }
                break;
        }
    }
    #endregion constructor

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
}
