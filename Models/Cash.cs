using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfAppGallery.Models
{
    public sealed class Cash
    {
        #region Singleton
        private static Cash _cash;
        private Cash()
        {
            _dataObjects = new List<ItemCash>();//При создании объекта определяем объём данных
        }

        public List<ItemCash> DataObjects => _dataObjects;

        public static Cash CreateInstance()
        {
            if (_cash == null) 
                _cash = new Cash();
            return _cash;
        }
        #endregion

        private const int MaxSize = 100;
        private readonly TimeSpan _timeSpanMaxValue = new TimeSpan(hours: 0, minutes: 0, seconds: 1, milliseconds: 999, days: 0);
        private const string DefaultPictureWayFolder = @"TODO: WayFolder";

        private List<ItemCash> _dataObjects;

        /// <summary>
        /// Добавляет документ в кэш
        /// </summary>
        /// <param name="value"></param>
        public void AddObject(ItemCash value) => DataObjects.Add(value);

        /// <summary>
        /// Удаляет элемент
        /// </summary>
        public void DeleteObject() => DataObjects.RemoveAt(DataObjects.Count - 1);

        /// <summary>
        /// Получить закешированный элемент
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetItem(int index)
        {
            if(index >= DataObjects.Count)
                throw new IndexOutOfRangeException("Не верно указанный размер");//TODO: обработка ошибки
            if (DataObjects[index].IsActive)
                throw new Exception();//TODO: реакция на активный элемент
            return DataObjects[index];
        }

        /// <summary>
        /// Метод сохраняет данные
        /// </summary>
        public void SaveCash()
        {
            throw new NotImplementedException();
        }


        public Task AddObjectAsync(ItemCash value) => Task.Run(() => { AddObject(value);});

        public Task DeleteObjectAsync() => Task.Run(DeleteObject);

        public Task<object> GetItemAsync(int index)
        {
            return Task.Run((() => GetItem(index)));
        }
    }
}