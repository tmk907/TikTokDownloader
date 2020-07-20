using System.Windows;

namespace TikTokDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel VM { get; }
        public MainWindow()
        {
            InitializeComponent();
            VM = new MainViewModel();
            DataContext = VM;
        }
    }
}
