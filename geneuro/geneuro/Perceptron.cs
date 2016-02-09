using System;
using System.IO;
using System.Threading.Tasks;

namespace geneuro {
    class Perceptron : INeuralNetwork {
        private Random random = new Random();
        private double learningRate;

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

        public int Classify(double[] input) {
            Impulse(input);

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

        private void Impulse(double[] input) {
            for (int j = 0; j < Layers[0].Length; j++)
                Layers[0][j].Output = input[j];

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

        public void Learn(TrainingSet trainingSet) {
            if (Settings.Instance.UseCustomLearningRate)
                learningRate = Settings.Instance.LearningRate;
            else
                learningRate = 1.0 / trainingSet.Size();

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
            const double alpha = 0.075;

            Impulse(example.Input);

            for (int j = 0; j < Layers[Layers.Length - 1].Length; j++)
                Layers[Layers.Length - 1][j].Delta = example.Output[j] - Layers[Layers.Length - 1][j].Output;

            for (int i = Layers.Length - 2; i >= 0; i--)
                Parallel.For(0, Layers[i].Length, j => {
                    Layers[i][j].Delta = Layers[i][j].DeltaSum();

                    for (int c = 0; c < Layers[i][j].Weights.Length; c++) {
                        Layers[i][j].DeltaWeights[c] = alpha * Layers[i][j].DeltaWeights[c] + (1.0 - alpha) * learningRate * Layers[i + 1][c].Delta * Layers[i][j].Output;
                        Layers[i][j].Weights[c] += Layers[i][j].DeltaWeights[c];
                    }
                });

            double error = 0;

            for (int j = 0; j < Layers[Layers.Length - 1].Length; j++)
                error += Layers[Layers.Length - 1][j].Delta * Layers[Layers.Length - 1][j].Delta;

            return error;
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

        public string Inspect() {
            string info = "";

            foreach (Neuron[] layer in Layers)
                info += layer.Length + " ";

            return info;
        }
    }
}
