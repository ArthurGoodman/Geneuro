using System.Drawing;

namespace geneuro {
    static class ImageLoader {
        public static double[] LoadImage(string fileName) {
            Bitmap image = (Bitmap)Image.FromFile(fileName);

            double[] data = new double[image.Width * image.Height];

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++) {
                    Color color = image.GetPixel(x, y);
                    data[x + x * y] = 1.0 - (double)(color.R + color.G + color.B) / 3 / 255;
                }

            return data;
        }
    }
}
