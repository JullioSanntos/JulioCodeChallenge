namespace JulioCode12.Common;

public class Trade {
    public string TradeId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public double Amount { get; set; }
    public DateTime MaturityDate { get; set; }
 
}