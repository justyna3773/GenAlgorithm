using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgorithm
{
	class DNA
	{
		public int[] Genes { get; private set; }
		public float Fitness { get; private set; }
		private Random random;
		private int geneMax;
		//private int getRandomGene;
		//private float FitnessFunction;

		public DNA(int size, Random random, int geneMax, bool shouldInitGenes = true)
		{
			this.Genes = new int[size];
			this.random = random;
			this.geneMax = geneMax;

			if (shouldInitGenes)
			{
				for (int i = 0; i < Genes.Length; i++)
				{
					this.Genes[i] = getRandomGene(geneMax);
				}
			}

		}
		public int getRandomGene(int geneMax)
		{
			int res = random.Next(0, geneMax);
			return res;
		}

		public float CalculateFitness()
		{
			float fitness = 0.0f;
			for (int i = 0; i < this.Genes.Length; i++)
			{
				fitness += this.Genes[i];
			}
			return fitness;
		}

		public void Mutate(float mutationRate)
		{
			for (int i = 0; i < Genes.Length; i++)
			{
				if (random.NextDouble() < mutationRate)
				{
					Genes[i] = getRandomGene(this.geneMax);
				}
			}
		}

		public DNA[] Crossover(DNA otherParent, int rangeCrossover)
		{
			/*if (rangeCrossover > Genes.Length - 1)
			{
				throw new ArgumentException("rangeCrossover too large for this length of genom");
			}*/
			rangeCrossover = Genes.Length - 1;
			DNA child1 = new DNA(Genes.Length, random, geneMax, shouldInitGenes: false);
			DNA child2 = new DNA(Genes.Length, random, geneMax, shouldInitGenes: false);
			DNA[] children = new DNA[2];
			Random randomIndexCrossing = new Random();
			long randomIndex = randomIndexCrossing.Next(1, rangeCrossover);
			int[] genes1 = new int[Genes.Length];
			int[] genes2 = new int[Genes.Length];
			//find a more elegant solution
			for (int i = 0; i < Genes.Length; i++)
			{
				if (i <= randomIndex)
				{
					child1.Genes[i] = this.Genes[i];
					child2.Genes[i] = otherParent.Genes[i];
				}
				else
				{
					child1.Genes[i] = otherParent.Genes[i];
					child2.Genes[i] = this.Genes[i];
				}

			}

			children[0] = child1;
			children[1] = child2;
			return children;
		}
		public override string ToString()
		{
			return string.Join(",", this.Genes);
		}

	}
}
