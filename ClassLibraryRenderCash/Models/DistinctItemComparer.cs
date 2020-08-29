using System.Collections.Generic;

namespace ClassLibraryRenderCash.Models
{
    internal class DistinctItemComparer : IEqualityComparer<Page>
    {

        public bool Equals(Page x, Page y)
        {
            return x.NumberPage == y.NumberPage;
        }

        public int GetHashCode(Page obj)
        {
            return obj.NumberPage.GetHashCode();
        }
    }
}