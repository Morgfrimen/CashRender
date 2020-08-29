using System;
using System.Threading.Tasks;
using ClassLibraryRenderCash;
using ClassLibraryRenderCash.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestCash
    {
        [TestMethod]
        public void Test_GetPage_RenderCashBitmap()
        {
            IRenderCash renderCashBitmap = new RenderCashImage();
            var page = renderCashBitmap.GetPage(0);
            var testPage = renderCashBitmap.GetPage(0);

            Assert.AreEqual(page.TimeSpanAddPage,testPage.TimeSpanAddPage);
            Assert.AreEqual(page.NumberPage,testPage.NumberPage);
        }

        [TestMethod]
        public void Test_MaxSize_Test_GetPage_RenderCashBitmap()
        {
            IRenderCash renderCashBitmap = new RenderCashImage(1);
            var page0 = renderCashBitmap.GetPage(0);
            var page1 = renderCashBitmap.GetPage(1);
            var page2 = renderCashBitmap.GetPage(2);

            var testAsync = new Task<Page>[]
                {renderCashBitmap.GetPageAsync(0), renderCashBitmap.GetPageAsync(1), renderCashBitmap.GetPageAsync(2)};

        }
    }
}
