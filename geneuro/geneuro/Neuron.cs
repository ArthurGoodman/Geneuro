namespace geneuro {
    class Neuron {
        private Perceptron perceptron;
        private int layer;

        public double[] Weights { get; set; }

        public double Output { get; set; }

        public double[] DeltaWeights { get; set; }
        public double Delta { get; set; }

        public Neuron(Perceptron perceptron, int layer) {
            this.perceptron = perceptron;
            this.layer = layer;
        }

        public void Propagate() {
            for (int c = 0; c < Weights.Length; c++) {
                perceptron.Layers[layer + 1][c].Output += Output * Weights[c];
            }
        }

        public double DeltaSum() {
            double sum = 0;

            for (int c = 0; c < Weights.Length; c++)
                sum += perceptron.Layers[layer + 1][c].Delta * Weights[c];

            return sum;
        }
    }
}
