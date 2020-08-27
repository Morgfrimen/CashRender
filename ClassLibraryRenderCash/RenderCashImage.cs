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
            if (base.GetPage(numberPage) == null)
            {
                if(_image == null)
                    DownloadImage();
                page = new Page(_image, numberPage, Extension.GetTimeSpanNow());
            }
            else
                page = GetDefaultPage(numberPage);

            AddPage(page);
            return page;

        }

        private void RenderCashImage_CashChangedEvent(object sender, CashChangedEventArgs e)
        {
            if (e.Operation1 == Operation.Cancel)
            {
                //TODO:Уведомить пользователя, что операция не прошла 
            }
        }

        //Закладывается смысл что тут нужно загрузить изображение, которое сейчас просматривает пользователь
        #region Download
        internal void DownloadImage(string wayFolderImage)
        {
            _image = new Bitmap(wayFolderImage);
        }

        internal void DownloadImage(Image wayFolderImage)
        {
            _image = wayFolderImage;
        }

        internal void DownloadImage()
        {
            _image = SystemIcons.Application.ToBitmap();
        } 
        #endregion
    }
}