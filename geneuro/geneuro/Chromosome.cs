using System;

namespace geneuro {
    class Chromosome {
        public double Unfitness { get; set; }
        public Perceptron Instance { get; set; }

        public int[] LayersSizes { get; set; }
        public double LearningRate { get; set; }

        public Chromosome() {
        }

        public Chromosome(int[] layersSizes, double learningRate) {
            LayersSizes = layersSizes;
            LearningRate = learningRate;
        }

        public void Instantiate() {
            int[] actualLayersSizes = new int[LayersSizes.Length + 2];
            actualLayersSizes[0] = 300;
            actualLayersSizes[actualLayersSizes.Length - 1] = 10;

            for (int i = 0; i < LayersSizes.Length; i++)
                actualLayersSizes[i + 1] = LayersSizes[i];

            Instance = new Perceptron(actualLayersSizes);
            Instance.Initialize();
        }

        public void Initialize(Random random) {
            LayersSizes = new int[random.Next(Settings.Instance.HiddenLayersCountRange.First, Settings.Instance.HiddenLayersCountRange.Second + 1)];

            for (int i = 0; i < LayersSizes.Length; i++)
                LayersSizes[i] = random.Next(Settings.Instance.HiddenLayerSizeRange.First, Settings.Instance.HiddenLayerSizeRange.Second + 1);

            LearningRate = random.NextDouble();
        }

        public void Evaluate(TrainingSet data, TrainingSet tests) {
            Instantiate();

            Settings.Instance.LearningRate = LearningRate;

            double dataError = Instance.Learn(data, false);
            double testsError = Instance.Test(data);

            const double alpha = 0.75;
            Unfitness = alpha * dataError + (1.0 - alpha) * testsError;
        }

        private int? Interpolate(int[] array, double index) {
            if (array.Length == 0)
                return null;

            if (array.Length == 1)
                return array[0];

            int a = (int)Math.Floor(index * (array.Length - 1));
            int b = (int)Math.Ceiling(index * (array.Length - 1));

            double f = index * (array.Length - 1) - Math.Floor(index * (array.Length - 1));

            return (int)(f * array[a] + (1 - f) * array[b]);
        }

        public Chromosome Crossover(Chromosome other) {
            int[] newLayersSizes = new int[(LayersSizes.Length + other.LayersSizes.Length) / 2];

            for (int i = 0; i < newLayersSizes.Length; i++) {
                double f = newLayersSizes.Length > 1 ? (double)i / (newLayersSizes.Length - 1) : 0.5;

                int? a = Interpolate(LayersSizes, f);
                int? b = Interpolate(other.LayersSizes, f);

                if (a == null)
                    a = b;
                else if (b == null)
                    b = a;

                newLayersSizes[i] = (int)(a + b) / 2;
            }

            return new Chromosome(newLayersSizes, (LearningRate + other.LearningRate) / 2);
        }

        public void Mutate(Random random) {
            const int mod = 16;

            if (random.Next() % mod == 0) {
                if (random.Next() % 2 == 0 && LayersSizes.Length < Settings.Instance.HiddenLayersCountRange.Second) {
                    int[] newLayersSizes = new int[LayersSizes.Length + 1];

                    for (int i = 0; i < LayersSizes.Length; i++)
                        newLayersSizes[i] = LayersSizes[i];

                    newLayersSizes[LayersSizes.Length] = random.Next(Settings.Instance.HiddenLayerSizeRange.First, Settings.Instance.HiddenLayerSizeRange.Second + 1);

                    LayersSizes = newLayersSizes;
                }
                else if(LayersSizes.Length > 0) {
                    int[] newLayersSizes = new int[LayersSizes.Length - 1];

                    for (int i = 0; i < LayersSizes.Length - 1; i++)
                        newLayersSizes[i] = LayersSizes[i];
                    
                    LayersSizes = newLayersSizes;
                }
            }

            for (int i = 0; i < LayersSizes.Length; i++)
                if (random.Next() % mod == 0) {
                    int delta = random.Next((Settings.Instance.HiddenLayerSizeRange.Second - Settings.Instance.HiddenLayerSizeRange.First) / 2);

                    if (random.Next() % 2 == 0)
                        delta *= -1;

                    if (LayersSizes[i] + delta >= Settings.Instance.HiddenLayerSizeRange.First && LayersSizes[i] + delta <= Settings.Instance.HiddenLayerSizeRange.Second)
                        LayersSizes[i] += delta;
                }


            if (random.Next() % mod == 0) {
                if (random.Next() % 2 == 0)
                    LearningRate -= random.NextDouble() * LearningRate;
                else
                    LearningRate += random.NextDouble() * (1.0 - LearningRate);
            }
        }
    }
}
