using System;

namespace ClassLibraryRenderCash.Extension
{
    internal static class Extension
    {
        internal static TimeSpan GetTimeSpanNow()
        {
            return DateTime.Now.TimeOfDay;
        }
    }
}