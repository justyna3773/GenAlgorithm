using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgorithm
{
	class Epoch
	{
		private int populationSize;
		private Population population1;
		private double crossoverProbability;
		private float mutationProbability;
		public Epoch(int populationSize, double crossoverProbability, int nep, float mutationProb, bool supressMessages = false)
		{
			this.populationSize = populationSize;
			this.crossoverProbability = crossoverProbability;
			this.mutationProbability = mutationProb;
			this.populationInitialize();
			if (!supressMessages)
			{
				printFitnesses();
			}
			this.callNEpochs(nep);
			Console.WriteLine("Wartości funkcji przystosowania po n crossoverach");
			population1.CalculateFitnesses();
			float sum2 = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum2 += i;
			}
			Console.WriteLine(sum2 / population1.fitnesses.Length);
			Console.ReadLine();

		}
		public void populationInitialize()
		{
			population1 = new Population(this.populationSize, this.mutationProbability);
			population1.initializePopulation();
			population1.CalculateFitnesses();

		}
		public void printFitnesses()
		{
			Console.WriteLine("Wyliczone wartości funkcji przystosowania: pokolenie rodziców");
			float sum = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum += i;
			}
			Console.WriteLine(sum / population1.fitnesses.Length);
		}

		public void callNEpochs(int n)
		{
			for (int i = 0; i < n; i++)
			{
				// you have to recalculate fitnesses
				population1.CalculateFitnesses();
				this.population1.replaceGeneration(this.population1.Crossovers(this.crossoverProbability));
				foreach (var k in population1.population_dna)
				{
					Console.WriteLine(k.ToString());
				}
				this.population1.introduceMutation();
			}
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
