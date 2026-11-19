using Common2D;
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

namespace GraphicEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap bitmap;
        PixelMap pixels = new PixelMap();

        public MainWindow()
        {
            InitializeComponent();

            bitmap = new WriteableBitmap(
            pixels.Width, pixels.Height,
            96, 96,
            PixelFormats.Bgra32,
            null
        );

            Display.Source = bitmap;

            Draw();
        }

        void Draw()
        {
            bitmap.Lock();

            unsafe
            {
                byte* pixels = (byte*)bitmap.BackBuffer;

                var pixelsArray = this.pixels.GetPixels();
                for (int i = 0; i < pixelsArray.Length; i++)
                {
                    pixels[i] = pixelsArray[i];
                }
            }

            bitmap.AddDirtyRect(
                new Int32Rect(0, 0, pixels.Width, pixels.Height)
            );

            bitmap.Unlock();
        }
    }
}