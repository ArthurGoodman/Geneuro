using System;

namespace geneuro {
    class Program {
        private static string networkFilePath = "network";

        static void Main(string[] args) {
            try {
                Run(args);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private static void InvalidArguments() {
            throw new Exception("error: invalid arguments");
        }

        static void Run(string[] args) {
            if (args.Length == 0)
                throw new Exception("error: invalid arguments\nUse /? or /help to see available commands");

            INeuralNetwork net;

            switch (args[0]) {
                case "/?":
                case "/help":
                    Console.WriteLine("This is help.");
                    break;

                case "/create":
                    if (args.Length < 2)
                        InvalidArguments();

                    int[] layersSizes = new int[args.Length - 1];

                    for (int i = 0; i < layersSizes.Length; i++)
                        layersSizes[i] = int.Parse(args[i + 1]);

                    net = new Perceptron(layersSizes);
                    net.Save(networkFilePath);
                    break;

                case "/learn":
                    if (args.Length != 2)
                        InvalidArguments();

                    string dataDirectoryPath = args[1];

                    net = new Perceptron();
                    net.Load(networkFilePath);
                    net.Learn(dataDirectoryPath);
                    net.Save(networkFilePath);
                    break;

                case "/classify":
                    if (args.Length != 2)
                        InvalidArguments();

                    string imagePath = args[1];

                    net = new Perceptron();
                    net.Load(networkFilePath);
                    Console.WriteLine(net.Classify(imagePath));
                    break;

                default:
                    InvalidArguments();
                    break;
            }
        }
    }
}
