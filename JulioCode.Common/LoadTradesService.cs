using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioCode12.Common;

public class LoadTradesService {
    public async Task<List<Trade>> GetTradesAsync(int minTransactions = 20, int maxTransactions = 40) {

        await Task.Delay(1);
        var tradeList = await Task.Run(() => GetRandomNumberOfTradesAsync(minTransactions, maxTransactions));
        //var tradeList = new List<Trade> {
        //new Trade("TSLA123", "Stocks", "Dollar", 200d, new DateTime(2026, 01, 01))
        //, new Trade("NVDA123", "Stocks", "Dollar", 200d, new DateTime(2026, 01, 01))
        //, new Trade("TSLA234", "Stocks", "Real", 200d, new DateTime(2026, 01, 01))
        //, new Trade("NVDA234", "Stocks", "Real", 200d, new DateTime(2026, 01, 01))

        //};
        return tradeList;
    }

    #region Randomizer
    private Randomizer? _randomizer;
    public Randomizer Randomizer {
        get { return _randomizer ??= new Randomizer(); }
    }
    #endregion Randomizer

    public async Task<List<Trade>> GetRandomNumberOfTradesAsync(int minTransactions, int maxTransactions) {
        var tradesCount = new Random().Next(minTransactions, maxTransactions);
        var tradesList = new List<Trade>(new Trade[tradesCount]);
        for (int i = 0; i < tradesList.Count; i++) {
            tradesList[i] = new Trade();
        }


        await PopulateTradesAsync(tradesList);
        return tradesList;
    }

    public async Task<List<Trade>> PopulateTradesAsync(List<Trade> tradesList) {
        var tradeIdTask = PopulateTradeIdAsync(tradesList);
        var currencyTask = PopulateCurrencyAsync(tradesList);
        await Task.WhenAll(tradeIdTask, currencyTask);
        return tradesList;
    }

    #region CurrenciesList
    private List<string>? _currenciesList;
    public List<string> CurrenciesList
    {
        get {
            if (_currenciesList != null) return _currenciesList;
              _currenciesList = new List<string>()
             { "Dollar", "Real", "Peso", "Ruble", "Euro", "Dinar", "Rupee", "Escudo", "franc" };
            return _currenciesList;
        }
    }
    #endregion CurrenciesList



    public async Task<List<Trade>> PopulateTradeIdAsync(List<Trade> tradesList) {
        foreach (var trade in tradesList) {
            trade.TradeId = Randomizer.GetWord(4, 8);
        }
        return tradesList;
    }

    public async Task<List<Trade>> PopulateCurrencyAsync(List<Trade> tradesList) {
        var randomCurr = new Random();
        foreach (var trade in tradesList) {
            trade.Currency = CurrenciesList[randomCurr.Next(CurrenciesList.Count)];
        }
        return tradesList;
    }

}
