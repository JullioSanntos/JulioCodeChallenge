using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace JulioCode12.Common;

public class LoadTradesService {
    public async Task<List<Trade>> GetTradesAsync(int minTransactions = 20, int maxTransactions = 40) {

        await Task.Delay(1500);
        var tradeList = await Task.Run(() => GetRandomNumberOfTradesAsync(minTransactions, maxTransactions));

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
        var typesTask = PopulateTypesAsync(tradesList);
        var currencyTask = PopulateCurrencyAsync(tradesList);
        var amountTask = PopulateAmountAsync(tradesList);
        var maturityDateTask = PopulateMaturityDateAsync(tradesList);
        await Task.WhenAll(tradeIdTask, typesTask, currencyTask, amountTask, maturityDateTask);
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

    #region TypesArr
    private string[]? _typesArr;
    public string[] TypesArr {
        get {
            if (_typesArr != null) { return _typesArr; }
                
            _typesArr = [ "stocks", "bonds", "derivatives", "currencies" ];

            return _typesArr;
        }
    }
    #endregion TypesArr



    public async Task<List<Trade>> PopulateTradeIdAsync(List<Trade> tradesList) {
        foreach (var trade in tradesList) {
            trade.TradeId = Randomizer.GetWord(4, 8);
        }
        return tradesList;
    }

    public async Task<List<Trade>> PopulateTypesAsync(List<Trade> tradesList) {
        var randomCurr = new Random();
        foreach (var trade in tradesList) {
            trade.Type = TypesArr[randomCurr.Next(TypesArr.Length - 1)];
        }
        return tradesList;
    }

    public async Task<List<Trade>> PopulateCurrencyAsync(List<Trade> tradesList) {
        var randomCurr = new Random();
        foreach (var trade in tradesList) {
            trade.Currency = CurrenciesList[randomCurr.Next(CurrenciesList.Count - 1)];
        }
        return tradesList;
    }

    public async Task<List<Trade>> PopulateAmountAsync(List<Trade> tradesList) {
        var randomCurr = new Random();
        foreach (var trade in tradesList) {
            trade.Amount = randomCurr.Next(100, 1000);
        }
        return tradesList;
    }

    public async Task<List<Trade>> PopulateMaturityDateAsync(List<Trade> tradesList) {
        var randomCurr = new Random();
        var startDate = DateTime.Now;
        startDate = startDate.AddMonths(3);
        foreach (var trade in tradesList) {
            trade.MaturityDate = startDate.AddDays(randomCurr.Next(100, 1000));
        }
        return tradesList;
    }

}
