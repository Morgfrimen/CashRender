using System.Threading.Tasks;
using ClassLibraryRenderCash.Models;

namespace ClassLibraryRenderCash
{
    public interface IRenderCash
    {
        /// <summary>
        /// Получить асинхронно страницу по номеру страницы
        /// </summary>
        /// <param name="numberPage">Номер страницы</param>
        /// <returns>Страницу</returns>
        Task<Page> GetPageAsync(uint numberPage);

        /// <summary>
        /// Получить страницу по номеру страницы
        /// </summary>
        /// <param name="numberPage">Номер страницы</param>
        /// <returns>Страницу</returns>
        Page GetPage(uint numberPage);
    }
}