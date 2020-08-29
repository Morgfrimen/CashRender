using System;

namespace ClassLibraryRenderCash.Models
{
    public sealed class CashChangedEventArgs:EventArgs
    {
        private readonly Operation _operation;
        private readonly Page _page;

        internal CashChangedEventArgs(Operation operation, Page page)
        {
            _operation = operation;
            _page = page;
        }

        public Operation Operation1 => _operation;

        public Page Pages => _page;
    }

    public enum Operation : byte
    {
        /// <summary>
        /// Добавление элемента в коллекцию
        /// </summary>
        Add,

        /// <summary>
        /// Удаление
        /// </summary>
        Delete,

        /// <summary>
        /// Отмена операции
        /// </summary>
        Cancel
    }
}