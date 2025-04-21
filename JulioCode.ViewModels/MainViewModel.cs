using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using JulioCode12.Common;
using JulioCode12.Common.WPF;

namespace JulioCode06.ViewModels; 
public class MainViewModel  {
    public ICommand LoadTradeCommand => new RelayCommand(async _ => await LoadTrades());

    #region List<trade>
    public List<Trade>? TradesList { get; set; }

    #endregion List<trade>

    public async Task LoadTrades() {
        var loadServices = new LoadTradesService();
        TradesList = await loadServices.GetTradesAsync();
        return;
    }
}
