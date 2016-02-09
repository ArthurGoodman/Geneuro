using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;

namespace geneuro {
    class TrainingSet : IEnumerable {
        private Example[] examples;

        public static TrainingSet Load(string dataDirectoryPath) {
            Example[] examples = new Example[Directory.GetFiles(dataDirectoryPath, "*", SearchOption.AllDirectories).Length];

            DirectoryInfo[] dirs = new DirectoryInfo(dataDirectoryPath).GetDirectories();

            int targetIndex = 0;
            int index = 0;

            foreach (DirectoryInfo dir in dirs) {
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                    examples[index++] = new Example((Bitmap)Image.FromFile(file.FullName), dirs.Length, targetIndex);

                targetIndex++;
            }

            return new TrainingSet(examples);
        }

        private TrainingSet(Example[] examples) {
            this.examples = examples;
        }

        public IEnumerator GetEnumerator() {
            return examples.GetEnumerator();
        }

        public int Size() {
            return examples.Length;
        }

        public void Shuffle(Random random) {
            examples = examples.OrderBy(x => random.Next()).ToArray();
        }
    }
}
