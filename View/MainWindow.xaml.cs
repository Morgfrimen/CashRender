using System.Windows;
using WpfAppGallery.Models;

namespace WpfAppGallery.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private async void Test()
        {
            Cash sCash = Cash.CreateInstance();
            var test = await sCash.GetItemAsync(0);
        }
    }
}
