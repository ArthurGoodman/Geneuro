namespace geneuro {
    class Example {
        public double[] Input { get; private set; }
        public double[] Output { get; private set; }

        public Example(double[] input, int outputSize, int targetIndex) {
            Input = input;
            Output = new double[outputSize];
            Output[targetIndex] = 1.0;
        }
    }
}
