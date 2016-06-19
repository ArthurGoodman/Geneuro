using System.Drawing;

namespace geneuro {
    static class ImageLoader {
        public static double[] LoadImage(string fileName) {
            Bitmap image = (Bitmap)Image.FromFile(fileName);

            double[] data = new double[image.Width * image.Height];
            
            for (int i = 0; i < data.Length; i++) {
                Color color = image.GetPixel(i % image.Width, i / image.Width);
                data[i] = 1.0 - (double)(color.A + color.R + color.G + color.B) / 4 / 255;
            }

            return data;
        }
    }
}
