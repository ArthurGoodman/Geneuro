using System.Drawing;
using System.IO;

namespace generator {
    class Generator {
        private char firstChar;
        private char lastChar;
        private string[] fonts;
        private int[] sizes;

        public Generator(char first, char last) {
            firstChar = first;
            lastChar = last;

            LoadFonts(Settings.Instance.FontsFile);
        }

        private void LoadFonts(string fileName) {
            string[] lines = File.ReadAllLines(fileName);
            fonts = new string[lines.Length];
            sizes = new int[lines.Length];
            int i = 0;

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;

                int index = line.LastIndexOf(' ');

                fonts[i] = line.Substring(0, index);
                sizes[i] = int.Parse(line.Substring(index + 1));

                i++;
            }
        }

        public void Generate() {
            if (Directory.Exists(Settings.Instance.OutputDir))
                Directory.Delete(Settings.Instance.OutputDir, true);

            Directory.CreateDirectory(Settings.Instance.OutputDir);

            for (char c = firstChar; c <= lastChar; c++)
                Directory.CreateDirectory(Settings.Instance.OutputDir + "/" + c);

            Brush brush = new SolidBrush(Color.Black);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < fonts.Length; i++) {
                Font font = new Font(fonts[i], sizes[i]);

                for (char c = firstChar; c <= lastChar; c++) {
                    Bitmap image = new Bitmap(Settings.Instance.Width, Settings.Instance.Height);

                    Graphics g = Graphics.FromImage(image);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawString(c.ToString(), font, brush, Settings.Instance.Width / 2, Settings.Instance.Height / 2, format);

                    image.Save(Settings.Instance.OutputDir + "/" + c + "/" + i + ".bmp");
                }
            }
        }
    }
}
