using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JulioCode12.Common;

namespace JulioCode99.Tests.JulioCode12.CommonTests {
    [TestClass]
    public class LoadTradeServiceTests {
        [TestMethod]
        public async Task LoadTradeServiceTest1() {
            var target = new LoadTradesService();
            var actual = await target.GetTradesAsync(1, 1);
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public async Task GetNumberOfTradesTest() {
            var target = new LoadTradesService();
            for (int i = 0; i < 10; i++) {
                var actual = await target.GetTradesAsync(5, 10);
                Assert.IsTrue(actual.Count >= 5 && actual.Count <= 10);
            }
        }

        [TestMethod]
        public async Task LoadTradeServiceTradeIdPopulatedTest() {
            var target = new LoadTradesService();
            var actual = await target.GetTradesAsync(3, 3);
            Assert.IsFalse(string.IsNullOrEmpty(actual[0].TradeId));
        }
    }
}
