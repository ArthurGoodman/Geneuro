namespace geneuro {
    interface INeuralNetwork {
        void Learn(string dataDirectoryPath);
        int Classify(string imagePath);

        void Save(string filePath);
        void Load(string filePath);
    }
}
