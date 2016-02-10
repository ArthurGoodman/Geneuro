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

            for (int j = 0; j < Length; j++) {
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
            if (next != null)
                foreach (Neuron neuron in Neurons)
                    neuron.Initialize(random);
        }

        public void Load(BinaryReader reader) {
            if (next != null)
                foreach (Neuron neuron in Neurons)
                    neuron.Load(reader);
        }

        public void Save(BinaryWriter writer) {
            if (next != null)
                foreach (Neuron neuron in Neurons)
                    neuron.Save(writer);
        }

        public void Assign(double[] input) {
            for (int j = 0; j < Length; j++)
                Neurons[j].Value = input[j];
        }

        public void Diff(double[] output) {
            for (int j = 0; j < Length; j++)
                Neurons[j].Delta = output[j] - Neurons[j].Value;
        }

        private double Sigmoid(double t) {
            return 1.0 / (1 + Math.Exp(-2 * 1.0 * t));
        }

        public void ForwardPropagate() {
            for (int j = 0; j < Length; j++)
                Neurons[j].ForwardPropagate(next);

            for (int j = 0; j < next.Length; j++)
                next[j].Value = Sigmoid(next[j].Value);
        }

        public void BackPropagate() {
            Parallel.For(0, Length, j => {
                Neurons[j].BackPropagate(next);
                Neurons[j].Adjust(next);
            });
        }

        public double Error() {
            double error = 0;

            for (int j = 0; j < Length; j++)
                error += Neurons[j].Delta * Neurons[j].Delta;

            return error;
        }

        public int MaxIndex() {
            int maxIndex = 0;
            double maxValue = 0;

            for (int j = 0; j < Length; j++)
                if (Neurons[j].Value > maxValue) {
                    maxValue = Neurons[j].Value;
                    maxIndex = j;
                }

            return maxIndex;
        }
    }
}
