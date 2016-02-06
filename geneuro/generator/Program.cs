using System;
using System.Drawing;
using System.IO;

namespace generator {
    class Program {
        private const int Width = 50;
        private const int Height = 50;

        private static Settings settings;

        static void Main(string[] args) {
            try {
                settings = new Settings(args);
                Generate();
            } catch (Exception e) {
                Console.WriteLine("error: " + e.Message);
            }
        }

        private static void Generate() {
            for (char c = settings.FirstChar; c <= settings.LastChar; c++)
                Directory.CreateDirectory("out/" + c);

            Brush brush = new SolidBrush(Color.Black);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < settings.Fonts.Length; i++) {
                Font font = new Font(settings.Fonts[i], settings.Sizes[i]);

                for (char c = settings.FirstChar; c <= settings.LastChar; c++) {
                    Bitmap image = new Bitmap(Width, Height);

                    Graphics g = Graphics.FromImage(image);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawString(c.ToString(), font, brush, Width / 2, Height / 2, format);

                    image.Save("out/" + c + "/" + i + ".bmp");
                }
            }
        }
    }
}
