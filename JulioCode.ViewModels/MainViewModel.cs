using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using JulioCode12.Common;
using JulioCode12.Common.WPF;

namespace JulioCode06.ViewModels; 
public class MainViewModel(LoadTradesService loadTradesService) : SetPropertyBase {
    public ICommand LoadTradeCommand => new RelayCommand(async _ => await LoadTrades());

    public LoadTradesService LoadTradesService { get; init; } = loadTradesService;

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

    public async Task LoadTrades() {
        BusyIndicatorVisibility = "Visible";
        TradesList = await LoadTradesService.GetTradesAsync();
        BusyIndicatorVisibility = "Collapsed";

        return;
    }
}
