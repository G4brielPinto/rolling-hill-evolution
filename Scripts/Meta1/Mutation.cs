using System;
using System.Diagnostics;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Runner.UnityApp.Car;

public class Mutation : IMutation
{
    public bool IsOrdered { get; private set; }

    public Mutation()
    {
        IsOrdered = true;
    }


    public void Mutate(IChromosome chromosome, float probability)
    {

        var carChromosome = (CarChromosome)chromosome;


        if (RandomizationProvider.Current.GetDouble() > probability)
        {
            return;
        }




        int pos1 = RandomizationProvider.Current.GetInt(0, carChromosome.Length / 2);

        int pos2 = RandomizationProvider.Current.GetInt(carChromosome.Length / 2, carChromosome.Length);


        int swapLength = Math.Min(pos2 - pos1, carChromosome.Length - pos2);


        for (int i = 0; i < swapLength; i++)
        {
            var geneA = carChromosome.GetGene(pos1 + i);
            var geneB = carChromosome.GetGene(pos2 + i);

            carChromosome.ReplaceGene(pos1 + i, geneB);
            carChromosome.ReplaceGene(pos2 + i, geneA);
        }
    }
}
