namespace geneuro {
    interface INeuralNetwork {
        void Initialize();

        void Learn(TrainingSet trainingSet);
        int Classify(double[] input);

        void Save(string filePath);
        void Load(string filePath);

        string Inspect();
    }
}
