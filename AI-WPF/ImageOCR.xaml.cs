using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Windows.Storage;

namespace AI_WPF
{
    /// <summary>
    /// Interaction logic for ImageOCR.xaml
    /// </summary>
    public partial class ImageOCR : Page
    {
        public ImageOCR()
        {
            InitializeComponent();
        }


        async private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    // Load the selected image
                    BitmapImage bitmapImage = new BitmapImage(new Uri(filePath));
                    imgDisplay.Source = bitmapImage;
                    var file = await StorageFile.GetFileFromPathAsync(filePath);
                    var stream = await file.OpenAsync(FileAccessMode.Read);
                    var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                    var bitmap = await decoder.GetSoftwareBitmapAsync();

                    var textRecognizer = new Microsoft.Windows.Vision.TextRecognition.TextRecognizer();
                    var recognizedText =  await textRecognizer.RecognizeTextFromImageAsync(bitmap, null);
                    for (int i = 0; i < recognizedText.Lines.Count(); i++)
                    {
                        var line = recognizedText.Lines[i];
                        string message = $"Line {i}: {line.Text}";
                        OutputBox.Text += Environment.NewLine + message;
                    }
                    //OutputBox.Text += message + Environment.NewLine;

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
