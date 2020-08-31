using ClassLibraryRenderCash.Models;

namespace ClassLibraryRenderCash
{
    public interface ICash
    {
        PageCash GetCash(uint numberPage);
    }
}