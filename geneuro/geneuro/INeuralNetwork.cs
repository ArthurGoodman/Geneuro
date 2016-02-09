namespace geneuro {
    interface INeuralNetwork {
        void Learn(TrainingSet trainingSet);
        int Classify(double[] input);

        void Save(string filePath);
        void Load(string filePath);
    }
}
