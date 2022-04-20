using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgorithm
{
	class Population
	{
		private int populationNumber { get; set; }
		public DNA[] population_dna { get; set; }
		public float[] fitnesses { get; set; }
		private double crossover_probability { get; set; }
		private int rangeCrossoverPopulation { get; set; }
		private float mutationProbability { get; set; }
		public Population(int populationNumber, float mutationProbability, bool replace = false)
		{
			//inicjalizacja populacji 
			//obliczenie funkcji przystosowania
			//przydzielenie prawdopodobieństw wylosowania dla osobników z najlepszą wartością funkcji przystosowania
			//parowanie indeksów i stosowanie crossoveru między nimi
			//znalezienie punktów krzyżowania - losowanie punnktów krzyżowania odbywa się w klasie DNA
			this.populationNumber = populationNumber;
			this.population_dna = new DNA[populationNumber];
			this.mutationProbability = mutationProbability;
			this.fitnesses = new float[population_dna.Length];
			this.rangeCrossoverPopulation = 9;

		}
		public bool initializePopulation()
		{

			Random rand = new Random();
			for (int i = 0; i < this.populationNumber; i++)
			{
				this.population_dna[i] = new DNA(3, rand, 10, true);
			}
			if (this.population_dna.Length > 0)
			{
				return true;
			}
			else return false;
		}
		public void CalculateFitnesses()
		{

			for (int i = 0; i < this.populationNumber; i++)
			{
				this.fitnesses[i] = population_dna[i].CalculateFitness();
			}
		}

		static int ProporSelect(double[] vals, Random rnd)
		{
			// vals[] can't be all 0.0s
			int n = vals.Length;

			double sum = 0.0;
			for (int i = 0; i < n; ++i)
				sum += vals[i];

			double accum = 0.0;
			double p = rnd.NextDouble();

			for (int i = 0; i < n; ++i)
			{
				accum += (vals[i] / sum);
				if (p < accum) return i;
			}
			return n - 1;  // last index
		}


		public int[] russianWheel()
		{
			//Random wheelRandom = new Random();
			int[] randomResults = new int[populationNumber];
			float[] fitnesses_copy = new float[fitnesses.Length];
			Array.Copy(this.fitnesses, fitnesses_copy, fitnesses.Length);
			double[] doubleArray = Array.ConvertAll(fitnesses_copy, x => (double)x);
			Roulette roulette = new Roulette(doubleArray);
			for (int i = 0; i < this.populationNumber; i++)
			{
				int ind = roulette.spin();
				randomResults[i] = ind;

			}
			return randomResults;
		}

		public Population Crossovers(double crossoverProbabibility)
		{
			int pairNumber = populationNumber / 2;
			DNA[] newGeneration = new DNA[populationNumber];
			int[] preferedIndexes = this.russianWheel();
			Population newGenerationPopulation = new Population(this.populationNumber, this.mutationProbability);
			Console.WriteLine("Preferred Indexes");
			foreach (int item in preferedIndexes)
			{
				Console.Write(item + ",");
			}
			for (int t = 0; t < preferedIndexes.Length; t = t + 2)
			{
				Random rand1 = new Random();
				double rCrossoverProb = rand1.Next(0, 1);
				if (rCrossoverProb < crossoverProbabibility)
				{
					// call crossovers for the pair
					DNA[] children = population_dna[preferedIndexes[t]].Crossover(population_dna[preferedIndexes[t + 1]], this.rangeCrossoverPopulation);
					newGeneration[t] = children[0];
					newGeneration[t + 1] = children[1];
				}

			}
			newGenerationPopulation.population_dna = newGeneration;
			return newGenerationPopulation;
		}

		public void replaceGeneration(Population replacingGeneration)
		{
			this.population_dna = replacingGeneration.population_dna;
		}

		public void introduceMutation()
		{
			for (int i = 0; i < this.populationNumber; i++)
			{
				this.population_dna[i].Mutate(this.mutationProbability);
			}
		}
	}
}
