namespace geneuro {
    public class Engine {
        public static IStreamOutput Output { get; set; }

        private static INeuralNetwork net;

        public static void Create(int[] layersSizes) {
            net = new Perceptron(layersSizes);
            net.Initialize();
            net.Save(Settings.Instance.NetworkFileName);
        }

        public static void Learn() {
            net = new Perceptron();
            net.Load(Settings.Instance.NetworkFileName);
            net.Learn(TrainingSet.Load(Settings.Instance.DataDirectoryPath));
            net.Save(Settings.Instance.NetworkFileName);
        }

        public static void Classify(string imagePath) {
            net = new Perceptron();
            net.Load(Settings.Instance.NetworkFileName);
            Output.WriteLine(net.Classify(ImageLoader.LoadImage(imagePath)).ToString());
        }
    }
}
