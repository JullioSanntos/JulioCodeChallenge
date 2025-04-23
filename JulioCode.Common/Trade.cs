namespace JulioCode12.Common;

public class Trade {
    public string TradeId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public double Amount { get; set; }
    public DateTime MaturityDate { get; set; }

    public bool  HasInvalidAmount => Amount < 350;
    public bool  HasInvalidMaturityDate => MaturityDate < DateTime.Now.AddMonths(3);

    #region InvalidTradeMessage
    private string? _invalidTradeMessage = null;
    public string? InvalidTradeMessage {
        get {
            if (_invalidTradeMessage != null) { return _invalidTradeMessage; }

            switch ((HasInvalidAmount, HasInvalidMaturityDate)) {
                case (true, true):
                    _invalidTradeMessage = @$"Trade ""{TradeId}"" has invalid Amount {Amount} and invalid Maturity date {MaturityDate}";
                    break;
                case (true, false):
                    _invalidTradeMessage = @$"Trade ""{TradeId}"" has invalid Amount {Amount}";
                    break;
                case (false, true):
                    _invalidTradeMessage = @$"Trade ""{TradeId}"" has invalid Maturity date {MaturityDate}";
                    break;
                default:
                    _invalidTradeMessage = String.Empty;
                    break;
            }

            //if (HasInvalidAmount && HasInvalidMaturityDate) {
            //    _invalidTradeMessage = $@"Trade ""{TradeId}"" has invalid Amount {Amount} and invalid Maturity date {MaturityDate}";
            //}
            //else if (HasInvalidAmount) {
            //    _invalidTradeMessage = @$"Trade ""{TradeId}"" has invalid Amount {Amount}";
            //}
            //else if (HasInvalidMaturityDate) {
            //    _invalidTradeMessage = @$"Trade ""{TradeId}"" has invalid Maturity date {MaturityDate}";
            //}
            //else { _invalidTradeMessage = String.Empty; }

            return _invalidTradeMessage!;
        }
    }
    #endregion InvalidTradeMessage

    public bool IsValid {
        get {
            var noInvalidMessage = string.IsNullOrEmpty(InvalidTradeMessage);
            return noInvalidMessage;
        }
    }
}