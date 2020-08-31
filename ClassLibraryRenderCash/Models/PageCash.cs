using System;
using System.Drawing;

namespace ClassLibraryRenderCash.Models
{
    /// <summary>
    /// Структура,которая представляет из себя страницу кэша
    /// </summary>
    public struct PageCash
    {
        private readonly TimeSpan _timeSpanPage;
        private readonly uint _numberPage;
        private readonly Image _image;

        public PageCash(Image image, uint numberPage, TimeSpan timeSpanPage)
        {
            _image = image;
            _numberPage = numberPage;
            _timeSpanPage = timeSpanPage;
        }

        public Image Image => _image;

        public uint NumberPage => _numberPage;

        public TimeSpan TimeSpanPage => _timeSpanPage;
    }
}