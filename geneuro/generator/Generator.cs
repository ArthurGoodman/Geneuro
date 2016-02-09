using System.Drawing;
using System.IO;

namespace generator {
    class Generator {
        private char firstChar;
        private char lastChar;
        private string[] fonts;

        public Generator(char first, char last) {
            firstChar = first;
            lastChar = last;

            LoadFonts(Settings.Instance.FontsFile);
        }

        private void LoadFonts(string fileName) {
            fonts = File.ReadAllLines(fileName);
        }

        private Font GetAdjustedFont(Graphics g, Font font, Size room) {
            const float bias = 10;

            float size = font.Size;
            float lowSize = 0, highSize = 100;

            for (int i = 0; i < 10; i++) {
                font = new Font(font.Name, (lowSize + highSize) / 2, font.Style);

                if (font.GetHeight(g) > room.Height + bias)
                    highSize = (lowSize + highSize) / 2;
                else
                    lowSize = (lowSize + highSize) / 2;
            }

            return font;
        }

        public void Generate() {
            if (Directory.Exists(Settings.Instance.OutputDir))
                Directory.Delete(Settings.Instance.OutputDir, true);

            Directory.CreateDirectory(Settings.Instance.OutputDir);

            for (char c = firstChar; c <= lastChar; c++)
                Directory.CreateDirectory(Settings.Instance.OutputDir + "/" + c);

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            Bitmap image = new Bitmap(Settings.Instance.Width, Settings.Instance.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            RectangleF layoutRectangle = new RectangleF(0, 0, image.Width, image.Height);

            const float offset = 4;
            RectangleF expandedRectangle = new RectangleF(0, 0, image.Width, image.Height + offset);
            
            for (int i = 0; i < fonts.Length; i++) {
                Font font = GetAdjustedFont(g, new Font(fonts[i], 10), image.Size);

                for (char c = firstChar; c <= lastChar; c++) {

                    g.FillRectangle(whiteBrush, layoutRectangle);
                    g.DrawString(c.ToString(), font, blackBrush, expandedRectangle, format);

                    image.Save(Settings.Instance.OutputDir + "/" + c + "/" + i + ".bmp");
                }
            }
        }
    }
}
