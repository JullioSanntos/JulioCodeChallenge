using JulioCode12.Common;

namespace JulioCode.Tests {
    [TestClass]
    public sealed class TradeTests {
        [TestMethod]
        public void TradeInstantiation() {
            /*"TSLA", "future trade", "Dollar", 200d, new DateTime(2026,01,01)*/
            var target = new Trade( );
            Assert.IsNotNull(target);
        }
    }
}
