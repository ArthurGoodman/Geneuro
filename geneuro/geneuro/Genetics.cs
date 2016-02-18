using System;
using System.Linq;

namespace geneuro {
    class Genetics {
        private Random random = new Random();

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
            Console.WriteLine(-1 + " > best: " + population.First().Instance.Inspect() + "; " + population.First().LearningRate + "\n");

            for (int i = 0; i < Settings.Instance.EvolutionEpochs; i++) {
                Selection();
                Crossover();
                Mutation();
                Evaluation();

                population = population.OrderBy(c => c.Unfitness).ToArray();
                
                Console.WriteLine(i + " > best: " + population.First().Instance.Inspect() + "; " + population.First().LearningRate + "\n");
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
                Console.WriteLine(i++ + ": " + chromosome.Instance.Inspect() + "; " + chromosome.LearningRate + " : " + chromosome.Unfitness);
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
