using System;
using System.Windows.Forms;

namespace geneuro {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        //static void Main(string[] args) {
        //    try {
        //        Settings.Load();
        //        Run(args);
        //    } catch (Exception e) {
        //        Console.WriteLine(e.Message);
        //    }
        //}

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

                case "/data":
                    if (args.Length != 2)
                        InvalidArguments();

                    Settings.Instance.DataDirectoryPath = args[1];
                    Settings.Save();
                    break;

                case "/tests":
                    if (args.Length != 2)
                        InvalidArguments();

                    Settings.Instance.TestsDirectoryPath = args[1];
                    Settings.Save();
                    break;

                case "/rate":
                    if (args.Length != 2)
                        InvalidArguments();

                    Settings.Instance.LearningRate = double.Parse(args[1]);
                    Settings.Save();
                    break;

                case "/create":
                    if (args.Length < 2)
                        InvalidArguments();

                    int[] layersSizes = new int[args.Length - 1];

                    for (int i = 0; i < layersSizes.Length; i++)
                        layersSizes[i] = int.Parse(args[i + 1]);

                    net = new Perceptron(layersSizes);
                    net.Initialize();
                    net.Save(Settings.Instance.NetworkFileName);
                    break;

                case "/learn":
                    if (args.Length != 1)
                        InvalidArguments();

                    net = new Perceptron();
                    net.Load(Settings.Instance.NetworkFileName);
                    net.Learn(TrainingSet.Load(Settings.Instance.DataDirectoryPath));
                    net.Save(Settings.Instance.NetworkFileName);
                    break;

                case "/classify":
                    if (args.Length != 2)
                        InvalidArguments();

                    string imagePath = args[1];

                    net = new Perceptron();
                    net.Load(Settings.Instance.NetworkFileName);
                    Console.WriteLine(net.Classify(ImageLoader.LoadImage(imagePath)));
                    break;

                case "/optimize":
                    Genetics genetics = new Genetics();
                    net = genetics.Optimize();
                    net.Save(Settings.Instance.NetworkFileName);
                    Settings.Save();
                    break;

                case "/inspect":
                    if (args.Length != 1)
                        InvalidArguments();

                    net = new Perceptron();
                    net.Load(Settings.Instance.NetworkFileName);
                    Console.WriteLine(net.Inspect());
                    break;

                default:
                    InvalidArguments();
                    break;
            }
        }
    }
}
