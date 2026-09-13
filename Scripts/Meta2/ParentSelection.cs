using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Runner.UnityApp.Car;
using UnityEngine;

public class ParentSelection : SelectionBase
{
    public ParentSelection() : base(2)
    {
    }




    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {

        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList();
        IList<IChromosome> parents = new List<IChromosome>();








        int subsetTournamentSize = 5;


        List<int> availableIndices = Enumerable.Range(0, population.Count).ToList();


        for (int i = 0; i < number; i++) {


            List<CarChromosome> tournament = new List<CarChromosome>();


            List<int> selectedIndices = availableIndices.OrderBy(a => Guid.NewGuid()).Take(subsetTournamentSize).ToList();
            for (int j = 0; j < subsetTournamentSize; j++) {
                tournament.Add(population[selectedIndices[j]]);
            }


            tournament.Sort((c1, c2) => c2.Fitness.CompareTo(c1.Fitness));


            CarChromosome winner = tournament[0];
            parents.Add(winner);


            availableIndices.Remove(population.IndexOf(winner));


        }





        return parents;
    }
}
