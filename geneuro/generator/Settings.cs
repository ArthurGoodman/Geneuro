using System.IO;
using System.Xml.Serialization;

namespace generator {
    public class Settings {
        public static Settings Instance { get; set; }

        static string SettingsFile = "settings.xml";

        [XmlElement("Width")]
        public int Width { get; set; }

        [XmlElement("Height")]
        public int Height { get; set; }

        [XmlElement("Fonts")]
        public string FontsFile { get; set; }

        [XmlElement("Output")]
        public string OutputDir { get; set; }

        public Settings() {
            Width = 50;
            Height = 50;
            FontsFile = "fonts.txt";
            OutputDir = "out";
        }

        public static void Load() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Stream stream;

            if (File.Exists(SettingsFile)) {
                stream = File.OpenRead(SettingsFile);
                Instance = (Settings)serializer.Deserialize(stream);
                stream.Close();
            } else Instance = new Settings();

            File.Delete(SettingsFile);

            stream = File.OpenWrite(SettingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();
        }

        public static void Save() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            Stream stream = File.OpenWrite(SettingsFile);
            serializer.Serialize(stream, Instance);
            stream.Close();
        }
    }
}
