using ClassLibraryRenderCash.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ClassLibraryRenderCash
{
    public abstract class Cash : ICash
    {
        private readonly Image _defaultImage = SystemIcons.WinLogo.ToBitmap();
        private readonly IDisplayApp displayApp;

        protected Cash()
        {
            displayApp = new DisplayImageTest();
            PageCash = new List<PageCash>();
        }

        protected Cash(uint maxSize) : this()
        {
            MaxSize = maxSize;
        }

        private uint MaxSize { get; set; } = 100;
        protected List<PageCash> PageCash { get; set; }

        private void Valid(uint numberPage)
        {
            //Очистка кэша по времени, если он заполнен
            if (PageCash.Count > MaxSize)
            {
                for (int i = 0; i < PageCash.Count - MaxSize; i++)
                {
                    PageCash.RemoveAt(PageCash.FindIndex(pagess =>
                        pagess.TimeSpanPage == PageCash.Min(pages => pages.TimeSpanPage)));
                }
            }
        }

        protected void AddPageCash(PageCash pageCash)
        {
            lock (PageCash)
            {
                PageCash.Add(pageCash);
            }
        }

        public virtual PageCash GetCash(uint numberPage)
        {
            Valid(numberPage);
            if (PageCash.Any(page => page.NumberPage == numberPage))
            {
                return PageCash.Find(page => page.NumberPage == numberPage);
            }

            PageCash pageCash = new PageCash(displayApp.GetImageDisplay(), numberPage,
                Extension.Extension.GetTimeSpanNow());
            AddPageCash(pageCash);
            return pageCash;
        }
    }
}