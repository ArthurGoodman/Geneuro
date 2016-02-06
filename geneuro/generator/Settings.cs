using System;
using System.IO;

namespace generator {
    class Settings {
        public char FirstChar { get; private set; }
        public char LastChar { get; private set; }
        public string[] Fonts { get; private set; }
        public int[] Sizes { get; private set; }

        public static void InvalidArguments() {
            throw new Exception("invalid arguments");
        }

        public Settings(string[] args) {
            if (args.Length != 3 || args[0].Length > 1 || args[1].Length > 1)
                InvalidArguments();

            FirstChar = args[0][0];
            LastChar = args[1][0];
            LoadFonts(args[2]);
        }

        private void LoadFonts(string fileName) {
            string[] lines = File.ReadAllLines(fileName);
            Fonts = new string[lines.Length];
            Sizes = new int[lines.Length];
            int i = 0;

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;

                int index = line.LastIndexOf(' ');

                Fonts[i] = line.Substring(0, index);
                Sizes[i] = int.Parse(line.Substring(index + 1));

                i++;
            }
        }
    }
}
