using System.Drawing;

namespace ClassLibraryRenderCash.Models
{
    internal sealed class DisplayImageTest : IDisplayApp
    {
        public Image GetImageDisplay()
        {
            return SystemIcons.Information.ToBitmap();
        }
    }
}