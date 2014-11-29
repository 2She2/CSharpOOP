using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int InitialBoarSize = 4;
        private const int BoarBiteSize = 2;

        public Boar(string name, Point location)
            : base(name, location, Boar.InitialBoarSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            int eatenMeatQuantity = 0;

            if (animal != null && animal.Size <= this.Size)
            {
                eatenMeatQuantity = animal.GetMeatFromKillQuantity();
            }

            return eatenMeatQuantity;
        }

        public int EatPlant(Plant plant)
        {
            int eatenPlantQuantity = 0;

            if (plant != null)
            {
                eatenPlantQuantity = plant.GetEatenQuantity(Boar.BoarBiteSize);
                this.Size++;
            }

            return eatenPlantQuantity;
        }
    }
}
