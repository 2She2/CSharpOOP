// 03. Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle,
//     but randomly stops at different positions for several simulation ticks and, for each of those stops,
//     creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.
// 04. Test the ChickenParticle class through the ParcticleSystemMain class.

namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        // Max value of the random number. This number is used to check if the chicken is stopped to lay particle(egg)
        private const int RandomInterval = 6;

        private Random randomGenerator;

        // The ticks delay to lay particle(egg)
        private uint ticksToLayParticle;
        private uint currentTicksToLayParticle;
        private int currentRandomNumber = 1;

        /// <summary>
        /// Only constructor. Initialize all variables
        /// </summary>
        /// <param name="position">Particle position</param>
        /// <param name="speed">Particle speed</param>
        /// <param name="matrixSize">Size of the matrix(field)</param>
        /// <param name="randomGenerator">variable of type Random</param>
        /// <param name="ticksToLayParticle">ticks delay to lay particle(egg)</param>
        public ChickenParticle(MatrixCoords position, MatrixCoords speed, MatrixCoords matrixSize, Random randomGenerator, uint ticksToLayParticle)
            : base(position, speed, matrixSize, randomGenerator)
        {
            // Ticks to lay particle are put in the constructor, so the user can set different value
            this.ticksToLayParticle = ticksToLayParticle;
            this.currentTicksToLayParticle = ticksToLayParticle;
            // Random is given in the constructor, so we can use one global Random variable, to avoid repetition of numbers
            this.randomGenerator = randomGenerator;
        }

        // Chicken particle stops to lay egg, if currentRnadomNumber == 0
        // Else update its position and generate new random number
        public override IEnumerable<Particle> Update()
        {
            // If we don't produce new chickens, just return the list of particles from the base class
            // If we produce, add the particles from the base class and add the new chicken
            if (currentRandomNumber != 0)
            {
                currentRandomNumber = GenRandomNumber();

                return base.Update();
            }
            // Chicken can be produced only if current number is 0
            else
            {
                // On each iteration, decrement tick to lay particle
                this.currentTicksToLayParticle--;

                // If ticks count is 0, we create new chicken particle, with same position as its "mother"
                if (currentTicksToLayParticle == 0)
                {
                    // Generate new random number, so the moving of the "mother" can continue
                    this.currentRandomNumber = GenRandomNumber();

                    this.currentTicksToLayParticle = this.ticksToLayParticle;

                    ChickenParticle currentlyProducedChickenParticle = new ChickenParticle(this.Position, new MatrixCoords(), this.MatrixSize, this.randomGenerator, this.ticksToLayParticle);

                    List<Particle> producedParticles = new List<Particle>();

                    // Add the base update and the currently produced chicken
                    producedParticles.AddRange(base.Update());
                    producedParticles.Add(currentlyProducedChickenParticle);

                    return producedParticles;
                }
                else
                {
                    // While the chicken is waiting to lay egg, it is not updated. Just return empy list
                    return new List<Particle>();
                }
            }
        }

        private int GenRandomNumber()
        {
            return randomGenerator.Next(RandomInterval);
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'C', 'h', 'i', 'c', 'k', 'e', 'n' } };
        }
    }
}
