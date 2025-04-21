using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioCode12.Common;

public class LoadTradesService {
    public async Task<List<Trade>> GetTradesAsync() {

        await Task.Delay(500);
        var tradeList = new List<Trade> {
        new Trade("TSLA", "future trade", "Dollar", 200d, new DateTime(2026, 01, 01))
        , new Trade("NVDA", "future trade", "Dollar", 200d, new DateTime(2026, 01, 01))

        };
        return tradeList;
    }
}
