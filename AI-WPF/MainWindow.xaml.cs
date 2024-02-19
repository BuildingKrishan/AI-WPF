using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Vision;
using Microsoft.Windows.Imaging;

namespace AI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("TextView.xaml", UriKind.Relative));
        }

        private void ImageOCR_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("ImageOCR.xaml", UriKind.Relative));
            //var textRecognizer = new Microsoft.Windows.Imaging.MagicEraser();

        }
    }
}