using ClassLibraryRenderCash.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestCash
    {
        private CashBitMap cashBitMapDefaultSize;
        private CashBitMap cashBitMapDefault;
        private uint defaultNumberPage = 5;

        [TestInitialize]
        public void TestCash_Initialize()
        {
            this.cashBitMapDefaultSize = new CashBitMap();
            cashBitMapDefault = new CashBitMap(0);
        }


        [TestMethod]
        public void Test_GetPage_CashBitMap()
        {
            var pageDefault = cashBitMapDefaultSize.GetCash(defaultNumberPage);
            var savePage = cashBitMapDefaultSize.GetCash(defaultNumberPage);

            Assert.AreEqual(pageDefault.TimeSpanPage, savePage.TimeSpanPage);
            Assert.AreEqual(pageDefault.NumberPage, savePage.NumberPage);
            Assert.AreEqual(pageDefault.Image, savePage.Image);
        }

        [TestMethod]
        public void Test_GetPage_CashBitMap_Size()
        {
            var pageDefault1 = cashBitMapDefault.GetCash(defaultNumberPage);
            var savePage1 = cashBitMapDefault.GetCash(defaultNumberPage);

            Assert.AreNotEqual(savePage1.TimeSpanPage, pageDefault1.TimeSpanPage);
        }
    }
}