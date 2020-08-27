using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibraryRenderCash.Models;
using System.Linq;

namespace ClassLibraryRenderCash
{
    public abstract class RenderCash : IRenderCash
    {
        protected delegate void CashChanged(object sender, CashChangedEventArgs e);

        protected event CashChanged CashChangedEvent;

        /// <summary>
        /// Максимальный размер кэша
        /// </summary>
        private const uint MaxSizeDefaultCash = 100;

        /// <summary>
        /// Кэш
        /// </summary>
        private List<Page> _pageCashList;

        /// <summary>
        /// Поле с размером кэша, если дефолтный в 100 не устраивает
        /// </summary>
        private readonly uint _maxSize = MaxSizeDefaultCash;

        /// <summary>
        /// Конструктор для случая, если максимальный размер мы хотим поменять
        /// </summary>
        /// <param name="maxSize">Ноное значение размера</param>
        protected RenderCash(uint maxSize):this()
        {
            _maxSize = maxSize;
        }

        /// <summary>
        /// Конструктор для того случая, если размер в 100 устраивает
        /// </summary>
        protected RenderCash()
        {
            _pageCashList = new List<Page>();
        }

        /// <summary>
        /// Поле с размером кэша, если дефолтный не устраивает
        /// </summary>
        public uint MaxSize => _maxSize;

        /// <summary>
        /// Кэш
        /// </summary>
        public List<Page> PageCash
        {
            get => _pageCashList;
            protected set => _pageCashList = value;
        }


        protected virtual Page GetDefaultPage(uint numberPage)
        {
            return new Page(default,numberPage,Extension.GetTimeSpanNow());
        }

        /// <summary>
        /// Добавляет элемент в кэш
        /// </summary>
        /// <param name="page"></param>
        protected virtual void AddPage(Page page)
        {
            if (PageCash.Count + 1 < MaxSize)
            {
                lock (PageCash)
                {
                    PageCash.Add(page);
                }
                OnCashChangedEvent(this, new CashChangedEventArgs(Operation.Add)); 
            }
            else
            {
                OnCashChangedEvent(this,new CashChangedEventArgs(Operation.Cancel));
            }
        }

        /// <summary>
        /// Добавляет элемент в кэш асинхронно
        /// </summary>
        /// <param name="page"></param>
        protected async void AddPageAsync(Page page)
        {
            await Task.Run(() => PageCash.Add(page));
        }

        /// <summary>
        /// Удаляет элемент
        /// </summary>
        /// <param name="page"></param>
        protected virtual void DeletePage(Page page)
        {
            lock (PageCash)
            {
                PageCash.RemoveAt((int)page); 
            }
            OnCashChangedEvent(this,new CashChangedEventArgs(Operation.Delete));
        }

        /// <summary>
        /// Удаляет элемент ассинронно
        /// </summary>
        /// <param name="page"></param>
        protected async void DeletePageAsync(Page page)
        {
            await Task.Run(() => DeletePage(page));
        }

        /// <summary>
        /// Получить страницу асинхронно
        /// </summary>
        /// <param name="numberPage">Номер страницы</param>
        /// <returns>Страница</returns>
        public async Task<Page> GetPageAsync(uint numberPage)
        {
            return await Task<Page>.Run(() => GetPage(numberPage));
        }

        public virtual Page GetPage(uint numberPage)
        {
            Validate(numberPage);
            var page = PageCash.Where(pages => pages.NumberPage == numberPage);
            if (page.Any())
            {
                return page.FirstOrDefault(item =>
                {
                    if (item == null)
                    {
                        item = GetDefaultPage(numberPage);
                    }

                    return true;
                });
            }

            return null;
        }

        /// <summary>
        /// Валидация
        /// </summary>
        protected void Validate(uint numberPage)
        {
            //Удаляем старые элементы
            if (PageCash.Count > MaxSize)
            {
                for (int indexPage = 0; indexPage < MaxSize - PageCash.Count; indexPage++)
                {
                    PageCash.RemoveAt(PageCash.FindIndex(page =>
                        page.TimeSpanAddPage == PageCash.Min(pages => pages.TimeSpanAddPage)));
                }
            }

            //Удаляем повторяющуюся страницы
             PageCash = PageCash.Distinct().ToList();
        }

        protected virtual void OnCashChangedEvent(object sender,CashChangedEventArgs e)
        {
            CashChangedEvent?.Invoke(sender, e);
        }
    }
}