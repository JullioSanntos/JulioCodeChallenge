using JulioCode12.Common;

namespace JulioCode.Tests {
    [TestClass]
    public sealed class TradeTests {
        [TestMethod]
        public void TradeInstantiation() {
            var target = new Trade("TSLA", "future trade", "Dollar", 200d, new DateTime(2026,01,01) );
            Assert.IsNotNull(target);
        }
    }
}
