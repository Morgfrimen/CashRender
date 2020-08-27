using System;

namespace ClassLibraryRenderCash.Models
{
    public static class Extension
    {
        public static TimeSpan GetTimeSpanNow() => DateTime.Now.TimeOfDay;
    }
}