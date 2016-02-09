using System.Drawing;

namespace geneuro {
    static class ImageLoader {
        public static double[] LoadImage(Bitmap image) {
            double[] data = new double[image.Width * image.Height];

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++) {
                    Color color = image.GetPixel(x, y);
                    data[x + y * x] = 1.0 - (double)(color.R + color.G + color.B) / 3 / 255;
                }

            return data;
        }
    }
}
