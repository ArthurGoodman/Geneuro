using System;
using System.IO;

namespace geneuro {
    class Perceptron : INeuralNetwork {
        public static double LearningRate { get; set; }

        private Random random = new Random();
        private Layer[] layers;

        public Perceptron() {
        }

        public Perceptron(int[] layersSizes) {
            layers = new Layer[layersSizes.Length];

            for (int i = layers.Length - 1; i >= 0; i--)
                layers[i] = new Layer(layersSizes[i], i < layers.Length - 1 ? layers[i + 1] : null);
        }

        public void Initialize() {
            foreach (Layer layer in layers)
                layer.Initialize(random);
        }

        public int Classify(double[] input) {
            Impulse(input);

            int maxIndex = 0;
            double maxValue = -1;

            for (int j = 0; j < layers[layers.Length - 1].Length; j++)
                if (layers[layers.Length - 1][j].Value > maxValue) {
                    maxValue = layers[layers.Length - 1][j].Value;
                    maxIndex = j;
                }

            return maxIndex;
        }

        private void Impulse(double[] input) {
            foreach (Layer layer in layers)
                layer.Reset();

            layers[0].Assign(input);

            for (int i = 0; i < layers.Length - 1; i++)
                layers[i].ForwardPropagate();
        }

        public void Learn(TrainingSet trainingSet) {
            if (Settings.Instance.UseCustomLearningRate)
                LearningRate = Settings.Instance.LearningRate;
            else
                LearningRate = 1.0 / trainingSet.Size();

            for (int step = 0; step < Settings.Instance.MaxLearningSteps; step++) {
                double totalError = 0;

                foreach (Example example in trainingSet)
                    totalError += LearnExample(example);

                Console.WriteLine(step + ": " + totalError);

                if (totalError <= Settings.Instance.MaxError)
                    break;

                trainingSet.Shuffle(random);
            }
        }

        private double LearnExample(Example example) {
            Impulse(example.Input);

            layers[layers.Length - 1].Diff(example.Output);

            for (int i = layers.Length - 2; i >= 0; i--)
                layers[i].BackPropagate();

            return layers[layers.Length - 1].Error();
        }

        public void Load(string filePath) {
            Stream stream = File.OpenRead(filePath);
            BinaryReader reader = new BinaryReader(stream);

            layers = new Layer[reader.ReadInt32()];

            for (int i = layers.Length - 1; i >= 0; i--)
                layers[i] = new Layer(reader.ReadInt32(), i < layers.Length - 1 ? layers[i + 1] : null);

            for (int i = layers.Length - 1; i >= 0; i--)
                layers[i].Load(reader);

            stream.Close();
        }

        public void Save(string filePath) {
            if (File.Exists(filePath))
                File.Delete(filePath);

            Stream stream = File.OpenWrite(filePath);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(layers.Length);

            for (int i = layers.Length - 1; i >= 0; i--)
                writer.Write(layers[i].Length);

            for (int i = layers.Length - 1; i >= 0; i--)
                layers[i].Save(writer);

            stream.Close();
        }

        public string Inspect() {
            string info = "";

            foreach (Layer layer in layers)
                info += layer.Neurons.Length + " ";

            return info;
        }
    }
}
