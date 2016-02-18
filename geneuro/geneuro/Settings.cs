using System;
using System.IO;
using System.Xml.Serialization;

namespace geneuro {
    public class Settings {
        public static Settings Instance { get; set; }

        private static string settingsFile = "settings.xml";

        public string NetworkFileName { get; set; }
        public string DataDirectoryPath { get; set; }
        public string TestsDirectoryPath { get; set; }

        public bool UseCustomLearningRate { get; set; }
        public double LearningRate { get; set; }

        public double MaxError { get; set; }
        public int MaxLearningSteps { get; set; }

        public int PopulationSize { get; set; }
        public int EvolutionEpochs { get; set; }
        public Range HiddenLayersCountRange { get; set; }
        public Range HiddenLayerSizeRange { get; set; }

        public Settings() {
            NetworkFileName = "network";
            DataDirectoryPath = "data";
            TestsDirectoryPath = "tests";

            UseCustomLearningRate = true;
            LearningRate = 0.1;

            MaxError = 1e-3;
            MaxLearningSteps = 300;

            PopulationSize = 64;
            EvolutionEpochs = 100;
            HiddenLayersCountRange = new Range(0, 1);
            HiddenLayerSizeRange = new Range(10, 300);
        }

        public static void Load() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Stream stream;

            if (File.Exists(settingsFile)) {
                stream = File.OpenRead(settingsFile);
                Instance = (Settings)serializer.Deserialize(stream);
                stream.Close();
            } else
                Instance = new Settings();

            File.Delete(settingsFile);

            stream = File.OpenWrite(settingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();

            Instance.ExpandEnvironmentVariables();
        }

        public static void Save() {
            if (File.Exists(settingsFile))
                File.Delete(settingsFile);

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            Stream stream = File.OpenWrite(settingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();
        }

        private void ExpandEnvironmentVariables() {
            DataDirectoryPath = Environment.ExpandEnvironmentVariables(DataDirectoryPath);
            TestsDirectoryPath = Environment.ExpandEnvironmentVariables(TestsDirectoryPath);
        }
    }
}
