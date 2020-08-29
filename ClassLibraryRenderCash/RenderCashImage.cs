using ClassLibraryRenderCash.Models;
using System.Drawing;

namespace ClassLibraryRenderCash
{
    /// <summary>
    /// Кэш для BitMap
    /// </summary>
    public sealed class RenderCashImage : RenderCash
    {
        private Image _image;

        public RenderCashImage()
        {
            CashChangedEvent += RenderCashImage_CashChangedEvent;
        }

        public RenderCashImage(uint maxSize) : base(maxSize)
        {
            CashChangedEvent += RenderCashImage_CashChangedEvent;
        }

        protected override Page GetDefaultPage(uint numberPage)
        {
            return new Page(SystemIcons.Information.ToBitmap(),numberPage,Extension.GetTimeSpanNow());
        }

        public override Page GetPage(uint numberPage)
        {
            Page page;
            if (base.GetPage(numberPage) != null)
            {
                DownloadImage();
                page = PageCash.Find(image=> image.NumberPage == numberPage);
            }
            else
            {
                page = GetDefaultPage(numberPage);
                AddPage(page);
            }
            return page;

        }

        private void RenderCashImage_CashChangedEvent(object sender, CashChangedEventArgs e)
        {
            if (e.Operation1 == Operation.Cancel)
            {
                //TODO: Реакция на отмену операции
            }
        }

        //Закладывается смысл что тут нужно загрузить изображение, которое сейчас просматривает пользователь
        #region Download

        /// <summary>
        /// Подгружаем по указанном пути
        /// </summary>
        /// <param name="wayFolderImage"></param>
        internal void DownloadImage(string wayFolderImage)
        {
            _image = new Bitmap(wayFolderImage);
        }
        /// <summary>
        /// Загружает сам объект Image
        /// </summary>
        internal void DownloadImage(Image wayFolderImage)
        {
            _image = wayFolderImage;
        }

        /// <summary>
        /// Только для теста
        /// </summary>
        internal void DownloadImage()
        {
            _image = SystemIcons.Application.ToBitmap();
        } 
        #endregion
    }
}