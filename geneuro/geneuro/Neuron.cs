using System;
using System.IO;

namespace geneuro {
    class Neuron {
        public double[] Weights { get; set; }

        public double Value { get; set; }

        public double[] DeltaWeights { get; set; }
        public double Delta { get; set; }

        public void Reset() {
            Value = 0;
            Delta = 0;
        }

        public void Initialize(Random random) {
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] = random.NextDouble();
        }

        public void Load(BinaryReader reader) {
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] = reader.ReadDouble();
        }

        public void Save(BinaryWriter writer) {
            for (int i = 0; i < Weights.Length; i++)
                writer.Write(Weights[i]);
        }

        public void ForwardPropagate(Layer nextLayer) {
            for (int c = 0; c < Weights.Length; c++)
                nextLayer[c].Value += Value * Weights[c];
        }

        public void BackPropagate(Layer nextLayer) {
            for (int c = 0; c < Weights.Length; c++)
                Delta += nextLayer[c].Delta * Weights[c];
        }

        public void Adjust(Layer nextLayer) {
            const double alpha = 0.075;

            for (int c = 0; c < Weights.Length; c++) {
                DeltaWeights[c] = alpha * DeltaWeights[c] + (1.0 - alpha) * Perceptron.LearningRate * nextLayer.Neurons[c].Delta * Value;
                Weights[c] += DeltaWeights[c];
            }
        }
    }
}
