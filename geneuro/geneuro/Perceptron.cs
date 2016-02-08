using System;
using System.Drawing;
using System.IO;

namespace geneuro {
    class Perceptron : INeuralNetwork {
        private Random random = new Random();

        public Neuron[][] Layers { get; private set; }

        public Perceptron() {
        }

        public Perceptron(int[] layersSizes) {
            Layers = new Neuron[layersSizes.Length][];

            for (int i = 0; i < Layers.Length; i++)
                Layers[i] = new Neuron[layersSizes[i]];

            for (int i = 0; i < Layers.Length; i++)
                for (int j = 0; j < Layers[i].Length; j++) {
                    Layers[i][j] = new Neuron(this, i);

                    if (i < Layers.Length - 1) {
                        Layers[i][j].Weights = new double[Layers[i + 1].Length];
                        Layers[i][j].DeltaWeights = new double[Layers[i + 1].Length];

                        for (int c = 0; c < Layers[i][j].Weights.Length; c++)
                            Layers[i][j].Weights[c] = random.NextDouble();
                    }
                }
        }

        public int Classify(string imagePath) {
            Impulse((Bitmap)Image.FromFile(imagePath));

            int maxIndex = 0;
            double maxValue = -1;

            for (int j = 0; j < Layers[Layers.Length - 1].Length; j++)
                if (Layers[Layers.Length - 1][j].Output > maxValue) {
                    maxValue = Layers[Layers.Length - 1][j].Output;
                    maxIndex = j;
                }

            return maxIndex;
        }

        private double Sigmoid(double t) {
            return 1.0 / (1 + Math.Exp(-2 * 1.0 * t));
        }

        private void Impulse(Bitmap image) {
            for (int j = 0; j < Layers[0].Length; j++) {
                Color color = image.GetPixel(j % image.Width, j / image.Width);
                Layers[0][j].Output = 1.0 - (double)(color.R + color.G + color.B) / 3 / 255;
            }

            for (int i = 1; i < Layers.Length; i++)
                for (int j = 0; j < Layers[i].Length; j++)
                    Layers[i][j].Output = 0;

            for (int i = 0; i < Layers.Length - 1; i++) {
                for (int j = 0; j < Layers[i].Length; j++)
                    Layers[i][j].Propagate();

                for (int j = 0; j < Layers[i + 1].Length; j++)
                    Layers[i + 1][j].Output = Sigmoid(Layers[i + 1][j].Output);
            }
        }

        public void Learn(string dataDirectoryPath) {
            const int maxNumberOfSteps = 1000;
            const double maxError = 1e-5;

            DirectoryInfo[] dirs = new DirectoryInfo(dataDirectoryPath).GetDirectories();

            for (int step = 0; step < maxNumberOfSteps; step++) {
                int t = 0;

                double averageTotalError = 0;
                int count = 0;

                foreach (DirectoryInfo dir in dirs) {
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files) {
                        averageTotalError += LearnFile((Bitmap)Image.FromFile(file.FullName), t);
                        count++;
                    }

                    t++;
                }

                averageTotalError /= count;

                Console.WriteLine(step + ": " + averageTotalError);

                if (Math.Abs(averageTotalError) <= maxError)
                    break;
            }
        }

        private double LearnFile(Bitmap image, int t) {
            const double eta = 0.1;
            const double alpha = 0.075;

            Impulse(image);

            for (int j = 0; j < Layers[Layers.Length - 1].Length; j++)
                Layers[Layers.Length - 1][j].Delta = (t == j ? 1.0 : 0.0) - Layers[Layers.Length - 1][j].Output;

            for (int i = Layers.Length - 2; i >= 0; i--)
                for (int j = 0; j < Layers[i].Length; j++)
                    Layers[i][j].Delta = Layers[i][j].DeltaSum();

            for (int i = Layers.Length - 2; i >= 0; i--)
                for (int j = 0; j < Layers[i].Length; j++)
                    for (int c = 0; c < Layers[i][j].Weights.Length; c++) {
                        Layers[i][j].DeltaWeights[c] = alpha * Layers[i][j].DeltaWeights[c] + (1.0 - alpha) * eta * Layers[i + 1][c].Delta * Layers[i][j].Output;
                        Layers[i][j].Weights[c] += Layers[i][j].DeltaWeights[c];
                    }

            double averageError = 0;

            for (int j = 0; j < Layers[Layers.Length - 1].Length; j++)
                averageError += Layers[Layers.Length - 1][j].Delta;

            averageError /= Layers[Layers.Length - 1].Length;

            return averageError;
        }

        public void Load(string filePath) {
            Stream stream = File.OpenRead(filePath);
            BinaryReader reader = new BinaryReader(stream);

            Layers = new Neuron[reader.ReadInt32()][];

            for (int i = 0; i < Layers.Length; i++)
                Layers[i] = new Neuron[reader.ReadInt32()];

            for (int i = 0; i < Layers.Length; i++)
                for (int j = 0; j < Layers[i].Length; j++) {
                    Layers[i][j] = new Neuron(this, i);

                    if (i < Layers.Length - 1) {
                        Layers[i][j].Weights = new double[Layers[i + 1].Length];
                        Layers[i][j].DeltaWeights = new double[Layers[i + 1].Length];

                        for (int c = 0; c < Layers[i][j].Weights.Length; c++)
                            Layers[i][j].Weights[c] = reader.ReadDouble();
                    }
                }

            stream.Close();
        }

        public void Save(string filePath) {
            if (File.Exists(filePath))
                File.Delete(filePath);

            Stream stream = File.OpenWrite(filePath);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(Layers.Length);

            for (int i = 0; i < Layers.Length; i++)
                writer.Write(Layers[i].Length);

            for (int i = 0; i < Layers.Length - 1; i++)
                for (int j = 0; j < Layers[i].Length; j++)
                    for (int c = 0; c < Layers[i][j].Weights.Length; c++)
                        writer.Write(Layers[i][j].Weights[c]);

            stream.Close();
        }
    }
}
