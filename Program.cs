using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAlgorithm
{
	class Program
	{
		static void Main(string[] args)
		{

			Epoch epoch1 = new Epoch(10, 0.9,20, 0.02f,false);
			/*Population population1 = new Population(10, 0.8f, true);
			Console.WriteLine(population1.initializePopulation());
			foreach (DNA i in population1.population_dna)
			{
		
				Console.WriteLine("Osobnik " + i.ToString());
			}
			population1.CalculateFitnesses();
			Console.WriteLine("Wybrane indeksy");
			foreach (int i in population1.russianWheel())
			{
				Console.Write(i+",");
			}
			Console.WriteLine("Wyliczone wartości funkcji przystosowania");
			float sum = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum += i;
			}
			Console.WriteLine("Średnia funkcji przystosowania");
			Console.WriteLine(sum / population1.fitnesses.Length);
			;
			population1.replaceGeneration(population1.Crossovers(0.75));
			Console.WriteLine("Populacja po wywołaniu crossoveru i zastąpieniu pokolenia");
			foreach (DNA i in population1.population_dna)
			{
				Console.WriteLine("Osobnik " + i.ToString());
			}
			Console.WriteLine("Wartości funkcji przystosowania po crossoverze");
			population1.CalculateFitnesses();
			float sum2 = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum2 += i;
			}
			Console.WriteLine("Średnia funkcji przystosowania");
			Console.WriteLine(sum2 / population1.fitnesses.Length);
			Console.ReadLine();*/
		}
	}
}
