namespace geneuro {
    interface INeuralNetwork {
        void Initialize();

        double Learn(TrainingSet trainingSet, bool verbose = true);
        double Test(TrainingSet trainingSet);
        int Classify(double[] input);

        void Save(string filePath);
        void Load(string filePath);

        string Inspect();
    }
}
