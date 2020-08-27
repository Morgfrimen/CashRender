using System;

namespace ClassLibraryRenderCash.Models
{
    public sealed class CashChangedEventArgs:EventArgs
    {
        private readonly Operation _operation;

        internal CashChangedEventArgs(Operation operation)
        {
            _operation = operation;
        }

        public Operation Operation1 => _operation;
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