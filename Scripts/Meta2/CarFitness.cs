using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Chromosomes;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using System.Linq;

namespace GeneticSharp.Runner.UnityApp.Car
{
    public class CarFitness : IFitness
    {
        public CarFitness()
        {
            ChromosomesToBeginEvaluation = new BlockingCollection<CarChromosome>();
            ChromosomesToEndEvaluation = new BlockingCollection<CarChromosome>();
        }

        public BlockingCollection<CarChromosome> ChromosomesToBeginEvaluation { get; private set; }
        public BlockingCollection<CarChromosome> ChromosomesToEndEvaluation { get; private set; }
        public double Evaluate(IChromosome chromosome)
        {
            var c = chromosome as CarChromosome;
            ChromosomesToBeginEvaluation.Add(c);
            float trackLenght = 4450f;

            float fitness = 0;
            do
            {
                Thread.Sleep(1000);


                float Distance = c.Distance;
                float EllapsedTime = c.EllapsedTime;
                float NumberOfWheels = c.NumberOfWheels;
                float CarMass = c.CarMass;
                int RoadCompleted = c.RoadCompleted ? 1 : 0;

                List<float> Velocities = c.Velocities;
                float SumVelocities = c.SumVelocities;

                List<float> Accelerations = c.Accelerations;
                float SumAccelerations = c.SumAccelerations;

                List<float> Forces = c.Forces;
                float SumTotalForces = c.SumForces;







                float bonusForDistanceTraveled = Normalize(trackLenght - Distance, 0, trackLenght, 1, 10);
                float forceUsed = Normalize(SumTotalForces, 0, 100000000, 1, 10);


                float percentage = (trackLenght - Distance) / trackLenght;
                if (percentage >= 0.25f) fitness += 1.0f;
                if (percentage >= 0.50f) fitness += 2.0f;
                if (percentage >= 0.75f) fitness += 3.0f;
                if (percentage >= 1.00f) fitness += 4.0f;

                fitness += bonusForDistanceTraveled;
                if (forceUsed != 0) fitness = (fitness / (forceUsed));






                c.Fitness = fitness;

            } while (!c.Evaluated);

            ChromosomesToEndEvaluation.Add(c);


            do
            {
                Thread.Sleep(1000);
            } while (!c.Evaluated);



            return fitness;
        }


        public float Normalize(float value, float min, float max, float a, float b)
        {
            return a + ((value - min) * (b - a)) / (max - min);
        }



    }
}