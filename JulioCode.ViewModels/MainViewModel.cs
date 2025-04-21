using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using JulioCode12.Common;
using JulioCode12.Common.WPF;

namespace JulioCode06.ViewModels; 
public class MainViewModel : SetPropertyBase  {
    public ICommand LoadTradeCommand => new RelayCommand(async _ => await LoadTrades());

    public LoadTradesService LoadTradesService { get; init; } = new LoadTradesService();

    public MainViewModel(LoadTradesService loadTradesService) {
        LoadTradesService = loadTradesService;
    }

    //public MainViewModel() { }

    #region TradesList
    private List<Trade>? _tradesList;
    public List<Trade> TradesList {
        get { return _tradesList ??= []; }
        set => SetProperty(ref _tradesList, value);
    }
    #endregion TradesList

    public async Task LoadTrades() {
        TradesList = await LoadTradesService.GetTradesAsync();
        return;
    }
}
