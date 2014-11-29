using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int InitialWolfSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, Wolf.InitialWolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            int eatenMeatQuantity = 0;

            if (animal != null)
            {
                if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
                {
                    eatenMeatQuantity = animal.GetMeatFromKillQuantity();
                }
            }

            return eatenMeatQuantity;
        }
    }
}
