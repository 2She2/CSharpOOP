using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int InitialLionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, Lion.InitialLionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            int eatenMeatQuantity = 0;
            int lionTwiceSize = this.Size * 2;

            if (animal != null && animal.Size <= lionTwiceSize)
            {
                eatenMeatQuantity = animal.GetMeatFromKillQuantity();
                this.Size++;
            }

            return eatenMeatQuantity;
        }
    }
}
