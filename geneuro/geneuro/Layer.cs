using System;
using System.IO;
using System.Threading.Tasks;

namespace geneuro {
    class Layer {
        private Layer next;

        public Neuron[] Neurons { get; set; }

        public int Length {
            get {
                return Neurons.Length;
            }
        }

        public Neuron this[int j] {
            get {
                return Neurons[j];
            }
        }

        public Layer(int size, Layer next) {
            Neurons = new Neuron[size];
            this.next = next;

            for (int j = 0; j < Neurons.Length; j++) {
                Neurons[j] = new Neuron();

                if (next != null) {
                    Neurons[j].Weights = new double[next.Length];
                    Neurons[j].DeltaWeights = new double[next.Length];
                }
            }
        }

        public void Reset() {
            foreach (Neuron neuron in Neurons)
                neuron.Reset();
        }

        public void Initialize(Random random) {
            foreach (Neuron neuron in Neurons)
                neuron.Initialize(random);
        }

        public void Load(BinaryReader reader) {
            foreach (Neuron neuron in Neurons)
                neuron.Load(reader);
        }

        public void Save(BinaryWriter writer) {
            foreach (Neuron neuron in Neurons)
                neuron.Save(writer);
        }

        public void Assign(double[] input) {
            for (int j = 0; j < Neurons.Length; j++)
                Neurons[j].Value = input[j];
        }

        public void Diff(double[] output) {
            for (int j = 0; j < Neurons.Length; j++)
                Neurons[j].Delta = output[j] - Neurons[j].Value;
        }

        private double Sigmoid(double t) {
            return 1.0 / (1 + Math.Exp(-2 * 1.0 * t));
        }

        public void ForwardPropagate() {
            for (int j = 0; j < Neurons.Length; j++)
                Neurons[j].ForwardPropagate(next);

            for (int j = 0; j < next.Neurons.Length; j++)
                next[j].Value = Sigmoid(next[j].Value);
        }

        public void BackPropagate() {
            const double alpha = 0.075;

            Parallel.For(0, Neurons.Length, j => {
                Neurons[j].BackPropagate(next);

                for (int c = 0; c < Neurons[j].Weights.Length; c++) {
                    Neurons[j].DeltaWeights[c] = alpha * Neurons[j].DeltaWeights[c] + (1.0 - alpha) * Perceptron.LearningRate * next.Neurons[c].Delta * Neurons[j].Value;
                    Neurons[j].Weights[c] += Neurons[j].DeltaWeights[c];
                }
            });
        }

        public double Error() {
            double error = 0;

            for (int j = 0; j < Neurons.Length; j++)
                error += Neurons[j].Delta * Neurons[j].Delta;

            return error;
        }
    }
}
