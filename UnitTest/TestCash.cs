using ClassLibraryRenderCash.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestCash
    {
        private CashBitMap _cashBitMapDefaultSize;
        private CashBitMap _cashBitMapDefault;

        public uint DefaultNumberPage { get; set; } = 5;

        [TestInitialize]
        public void TestCash_Initialize()
        {
            this._cashBitMapDefaultSize = new CashBitMap();
            _cashBitMapDefault = new CashBitMap(0);
        }


        [TestMethod]
        public void Test_GetPage_CashBitMap()
        {
            var pageDefault = _cashBitMapDefaultSize.GetCash(DefaultNumberPage);
            var savePage = _cashBitMapDefaultSize.GetCash(DefaultNumberPage);

            Assert.AreEqual(pageDefault.TimeSpanPage, savePage.TimeSpanPage);
            Assert.AreEqual(pageDefault.NumberPage, savePage.NumberPage);
            Assert.AreEqual(pageDefault.Image, savePage.Image);
        }

        [TestMethod]
        public void Test_GetPage_CashBitMap_Size()
        {
            var pageDefault1 = _cashBitMapDefault.GetCash(DefaultNumberPage);
            var savePage1 = _cashBitMapDefault.GetCash(DefaultNumberPage);

            Assert.AreNotEqual(savePage1.TimeSpanPage, pageDefault1.TimeSpanPage);
        }
    }
}