using System.Drawing;

namespace geneuro {
    class Example {
        public double[] Input { get; private set; }
        public double[] Output { get; private set; }

        public Example(Bitmap image, int outputSize, int targetIndex) {
            Input = ImageLoader.LoadImage(image);
            Output = new double[outputSize];
            Output[targetIndex] = 1.0;
        }
    }
}
