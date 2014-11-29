using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int SimulationRows = 30;
        const int SimulationCols = 40;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            //var particleOperator = new AdvancedParticleOperator();

            // Initialize the repeller particle operator
            var repellerparticleOperator = new RepellerParticleOperator();

            var particles = new List<Particle>()
            {
                new Particle(new MatrixCoords(5, 5), new MatrixCoords(1, 1)),
                //new ParticleEmitter(new MatrixCoords(5, 10), new MatrixCoords(0, 0), RandomGenerator),
                //new ParticleEmitter(new MatrixCoords(5, 20), new MatrixCoords(0, 0), RandomGenerator),
                //new VariousLifetimeParticleEmitter(new MatrixCoords(29, 1), new MatrixCoords(0, 0), RandomGenerator),

                //new ParticleAttractor(new MatrixCoords(15, 8), new MatrixCoords(), 5),
                //new ParticleAttractor(new MatrixCoords(15, 20), new MatrixCoords(), 1),

                // 01. Create a ChaoticParticle
                //new ChaoticParticle(new MatrixCoords(), new MatrixCoords(), new MatrixCoords(SimulationRows, SimulationCols), RandomGenerator),

                // 03. Create a ChickenParticle
                //new ChickenParticle(new MatrixCoords(), new MatrixCoords(), new MatrixCoords(SimulationRows, SimulationCols), RandomGenerator, 5),

                // 05. Implement a ParticleRepeller
                //new ParticleRepeller(new MatrixCoords(13, 13), new MatrixCoords(), 2, 5),
            };

            // Using the repeller particle operator
            var engine = new Engine(renderer, repellerparticleOperator, particles, 500);

            engine.Run();
        }
    }
}
