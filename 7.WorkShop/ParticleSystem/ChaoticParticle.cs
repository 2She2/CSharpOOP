// 01. Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
//     You are not allowed to edit any existing class.
// 02. Test the ChaoticParticle through the ParticleSystemMain class - Program, line 46

namespace ParticleSystem
{
    using System;

    public class ChaoticParticle : Particle
    {
        private Random randomGenerator;

        /// <summary>
        /// Only constructor. Initialize all variables
        /// </summary>
        /// <param name="position">Particle position</param>
        /// <param name="speed">Particle speed</param>
        /// <param name="matrixSize">Size of the matrix(field)</param>
        /// <param name="randomGenerator">variable of type Random</param>
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, MatrixCoords matrixSize, Random randomGenerator)
            : base(position, speed)
        {
            // We need the matrix size, so we always print the chaotic particle inside the matrix
            this.MatrixSize = matrixSize;
            // Random is given in the constructor, so we can use one global Random variable, to avoid repetition of numbers
            this.randomGenerator = randomGenerator;
        }

        public MatrixCoords MatrixSize { get; protected set; }

        // Overriden method "Move()" to first set the chaotic particle to a random position, then call the base method
        protected override void Move()
        {
            this.Position = GenerateRandomPosition();
            base.Move();
        }

        // Generate random position inside the matrix
        private MatrixCoords GenerateRandomPosition()
        {
            MatrixCoords randomPosition = new MatrixCoords();

            randomPosition.Row = randomGenerator.Next(this.MatrixSize.Row);
            randomPosition.Col = randomGenerator.Next(this.MatrixSize.Col);

            return randomPosition;
        }

        // Overriden method get specific chaotic image
        public override char[,] GetImage()
        {
            return new char[,] { { 'C', 'h', 'a', 'o', 't', 'i', 'c' } };
        }
    }
}
