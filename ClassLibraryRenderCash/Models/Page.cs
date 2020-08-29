using System;

namespace ClassLibraryRenderCash.Models
{
    /// <summary>
    /// Каринка или документ
    /// </summary>
    public sealed class Page
    {
        public bool Equals(Page pageOne, Page pageTwo)
        {
            return pageOne.NumberPage == pageTwo.NumberPage;
        }

        /// <summary>
        /// Содержание страницы
        /// </summary>
        private readonly object _dataObject;

        /// <summary>
        /// Номер страницы
        /// </summary>
        private readonly uint _numberPage;

        /// <summary>
        /// Время добавления страницы
        /// </summary>
        private readonly TimeSpan _timeSpanAddPage;

        public Page(object dataObject, uint numberPage, TimeSpan timeSpanAddPage)
        {
            _dataObject = dataObject;
            _numberPage = numberPage;
            _timeSpanAddPage = timeSpanAddPage;
        }

        /// <summary>
        /// Содержание страницы
        /// </summary>
        public object DataObject => _dataObject;

        /// <summary>
        /// Номер страницы
        /// </summary>
        public uint NumberPage => _numberPage;

        /// <summary>
        /// Время добавления страницы
        /// </summary>
        public TimeSpan TimeSpanAddPage => _timeSpanAddPage;

        public static explicit operator int(Page page)
        {
            try
            {
                return checked((int)page.NumberPage);
            }
            catch (OverflowException)
            {
                return int.MaxValue;
            }
        }

        public static explicit operator TimeSpan(Page page)
        {
            return page.TimeSpanAddPage;
        }
    }
}
