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
            if (Weights != null)
                for (int i = 0; i < Weights.Length; i++)
                    Weights[i] = random.NextDouble();
        }

        public void Load(BinaryReader reader) {
            if (Weights != null)
                for (int i = 0; i < Weights.Length; i++)
                    Weights[i] = reader.ReadDouble();
        }

        public void Save(BinaryWriter writer) {
            if (Weights != null)
                for (int i = 0; i < Weights.Length; i++)
                    writer.Write(Weights[i]);
        }

        public void ForwardPropagate(Layer layer) {
            for (int c = 0; c < Weights.Length; c++)
                layer.Neurons[c].Value += Value * Weights[c];
        }

        public void BackPropagate(Layer layer) {
            for (int c = 0; c < Weights.Length; c++)
                Delta += layer.Neurons[c].Delta * Weights[c];
        }
    }
}
