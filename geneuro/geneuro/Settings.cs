using System;
using System.IO;
using System.Xml.Serialization;

namespace geneuro {
    public class Settings {
        public static Settings Instance { get; set; }

        static string SettingsFile = "settings.xml";

        [XmlElement("NetworkFileName")]
        public string NetworkFileName { get; set; }

        [XmlElement("DataDirectoryName")]
        public string DataDirectoryPath { get; set; }

        [XmlElement("TestsDirectoryName")]
        public string TestsDirectoryPath { get; set; }

        [XmlElement("UseCustomLearningRate")]
        public bool UseCustomLearningRate { get; set; }

        [XmlElement("LearningRate")]
        public double LearningRate { get; set; }

        [XmlElement("MaxError")]
        public double MaxError { get; set; }

        [XmlElement("MaxLearningSteps")]
        public int MaxLearningSteps { get; set; }

        public Settings() {
            NetworkFileName = "network";
            DataDirectoryPath = "data";
            TestsDirectoryPath = "tests";
            UseCustomLearningRate = false;
            LearningRate = 0.1;
            MaxError = 1e-3;
            MaxLearningSteps = 1000;
        }

        public static void Load() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Stream stream;

            if (File.Exists(SettingsFile)) {
                stream = File.OpenRead(SettingsFile);
                Instance = (Settings)serializer.Deserialize(stream);
                stream.Close();
            } else
                Instance = new Settings();

            File.Delete(SettingsFile);

            stream = File.OpenWrite(SettingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();

            Instance.ExpandEnvironmentVariables();
        }

        public static void Save() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            Stream stream = File.OpenWrite(SettingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();
        }

        private void ExpandEnvironmentVariables() {
            DataDirectoryPath = Environment.ExpandEnvironmentVariables(DataDirectoryPath);
            TestsDirectoryPath = Environment.ExpandEnvironmentVariables(TestsDirectoryPath);
        }
    }
}
