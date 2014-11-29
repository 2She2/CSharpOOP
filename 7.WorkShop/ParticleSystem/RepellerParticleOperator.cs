namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    // Inherit "AdvancedParticleOperator", so we can manage previous types of particle
    // Other way is to inherit "ParticleUpdater", but the "ParticleAttractor" will not work
    public class RepellerParticleOperator : AdvancedParticleOperator
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialRepeller = p as ParticleRepeller;
            if (potentialRepeller != null)
            {
                currentTickRepellers.Add(potentialRepeller);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToRepellerVector = repeller.Position - particle.Position;

                    // If particle is in the radius(range), repel it. 
                    // Using the same logic as "AdvancedParticleOperator". Using "Euclidean distance" formula to calculate the distance between the two particles
                    if (IsInRange(currParticleToRepellerVector, repeller))
                    {
                        int pToRepRow = currParticleToRepellerVector.Row;
                        pToRepRow = DecreaseVectorCoordToPower(repeller, pToRepRow);

                        int pToRepCol = currParticleToRepellerVector.Col;
                        pToRepCol = DecreaseVectorCoordToPower(repeller, pToRepCol);

                        var currAcceleration = new MatrixCoords(pToRepRow, pToRepCol);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.currentTickParticles.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToRepCoord)
        {
            if (pToRepCoord != 0 && Math.Abs(pToRepCoord) > repeller.RepelPower)
            {
                pToRepCoord = (pToRepCoord / (int)Math.Abs(pToRepCoord)) * repeller.RepelPower;
            }
            return pToRepCoord;
        }

        // Check if given particle is in the range(radius) of the repeller
        // Using "Euclidean distance" formula to calculate the distance between the two particles
        private bool IsInRange(MatrixCoords subtractedCoords, ParticleRepeller repeller)
        {
            int range = subtractedCoords.Col * subtractedCoords.Col + subtractedCoords.Row * subtractedCoords.Row;

            return range <= repeller.RepellerRadius * repeller.RepellerRadius;
        }
    }
}
