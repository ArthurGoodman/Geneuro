using System;
using System.IO;
using System.Linq;

namespace geneuro {
    class Genetics {
        private Random random = new Random();
        public static DateTime Today { get; }

        private Chromosome[] population;
        private Chromosome[] parents;

        private TrainingSet data;
        private TrainingSet tests;

        public Perceptron Optimize() {
            Settings.Instance.UseCustomLearningRate = true;

            data = TrainingSet.Load(Settings.Instance.DataDirectoryPath);
            tests = TrainingSet.Load(Settings.Instance.TestsDirectoryPath);

            Initialize();

            Evaluation();

            string info = -1 + " > best: " + population.First().Instance.Inspect() + "; " + population.First().LearningRate + "\n";
            Console.WriteLine(info);

            for (int i = 0; i < Settings.Instance.EvolutionEpochs; i++) {
                Selection();
                Crossover();
                Mutation();
                Evaluation();

                population = population.OrderBy(c => c.Unfitness).ToArray();

                info = i + " > best: " + population.First().Instance.Inspect() + "; " + population.First().LearningRate + "\n";

                Console.WriteLine(info);
            }

            return population.First().Instance;
        }
    
        private void Initialize() {
            population = new Chromosome[Settings.Instance.PopulationSize];

            for (int i = 0; i < population.Length; i++) {
                population[i] = new Chromosome();
                population[i].Initialize(random);
            }
        }

        private void Evaluation() {
            int i = 0;

            foreach (Chromosome chromosome in population) {
                chromosome.Evaluate(data, tests);

                string info = i++ + ": " + chromosome.Instance.Inspect() + "; " + chromosome.LearningRate + " : " + chromosome.Unfitness;
                Console.WriteLine(info);
            }
        }

        private void Selection() {
            parents = population.OrderBy(c => c.Unfitness).Take((int)Math.Sqrt(Settings.Instance.PopulationSize)).ToArray();
        }

        private void Crossover() {
            Chromosome[] newPopulation = new Chromosome[population.Length];
            int i = 0;

            foreach (Chromosome a in parents)
                foreach (Chromosome b in parents)
                    newPopulation[i++] = a.Crossover(b);

            population = newPopulation;
        }

        private void Mutation() {
            foreach (Chromosome chromosome in population)
                chromosome.Mutate(random);
        }
    }
}
