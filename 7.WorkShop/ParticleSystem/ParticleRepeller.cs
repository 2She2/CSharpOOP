// 05. Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it
//     (i.e. accelerates them in a direction, opposite of the direction in which the repeller is).
//     The repeller has an effect only on particles within a certain radius (see Euclidean distance)
// 06. Test the ParticleRepeller class through the ParticleSystemMain class

namespace ParticleSystem
{
    public class ParticleRepeller : Particle
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repelPower, int repellerRadius)
            : base(position, speed)
        {
            // Here we put minus '-', because we want to repel the particle, not to attract it
            // Other logic is the same as "Particle attractor"
            this.RepelPower = -repelPower;
            this.RepellerRadius = repellerRadius;
        }

        public int RepellerRadius { get; private set; }

        public int RepelPower { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
