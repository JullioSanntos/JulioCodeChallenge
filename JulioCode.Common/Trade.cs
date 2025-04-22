namespace JulioCode12.Common;

public class Trade {
    public string TradeId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public double Amount { get; set; }
    public DateTime MaturityDate { get; set; }

    private string? _invalidTrades = null;
    public string InvalidTrades {
        get {
            if (_invalidTrades != null) { return _invalidTrades; }

            if (Amount < 100 && MaturityDate > DateTime.Now.AddDays(90)) {
                _invalidTrades = $"Trade \"{TradeId}\" has invalid Amount {Amount} and invalid Maturity date {MaturityDate}";
            }
            else if (Amount < 100) {
                _invalidTrades = $"Trade {TradeId} has invalid Amount {Amount}";
            }
            else if (MaturityDate > DateTime.Now.AddDays(90)) {
                _invalidTrades = $"Trade {TradeId} has invalid Maturity date {MaturityDate}";
            }

            return _invalidTrades!;
        }
    }

    public bool IsValid => InvalidTrades.Any() == false;
}