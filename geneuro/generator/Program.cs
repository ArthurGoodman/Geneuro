using System;

namespace generator {
    class Program {
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

        private static void Run(string[] args) {
            Settings.Load();

            if (args.Length == 0) {
                InvalidArguments();
                Console.WriteLine("Use /? or /help to see available commands\n");
                return;
            }

            switch (args[0]) {
                case "/?":
                case "/help":
                    Console.WriteLine("/? or /help");
                    Console.WriteLine("/size <int> <int>");
                    Console.WriteLine("/fonts <file_path>");
                    Console.WriteLine("    fonts file format: (<font_name> <em_size> \\n)*");
                    Console.WriteLine("/output <directory_path>");
                    Console.WriteLine("/generate <first_character> <last_character>");
                    break;

                case "/size":
                    if (args.Length != 3)
                        InvalidArguments();

                    Settings.Instance.Width = int.Parse(args[1]);
                    Settings.Instance.Height = int.Parse(args[2]);

                    Settings.Save();
                    break;

                case "/fonts":
                    if (args.Length != 2)
                        InvalidArguments();

                    Settings.Instance.FontsFile = args[1];

                    Settings.Save();
                    break;

                case "/output":
                    if (args.Length != 2)
                        InvalidArguments();

                    Settings.Instance.OutputDir = args[1];

                    Settings.Save();
                    break;

                case "/generate":
                    if (args.Length != 3)
                        InvalidArguments();

                    new Generator(args[1][0], args[2][0]).Generate();
                    break;

                default:
                    InvalidArguments();
                    break;
            }
        }
    }
}
