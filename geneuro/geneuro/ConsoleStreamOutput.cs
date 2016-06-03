using System;

namespace geneuro {
    class ConsoleStreamOutput : IStreamOutput {
        public void Write(object str) {
            Console.Write(str);
        }

        public void WriteLine(object str) {
            Console.WriteLine(str);
        }
    }
}
