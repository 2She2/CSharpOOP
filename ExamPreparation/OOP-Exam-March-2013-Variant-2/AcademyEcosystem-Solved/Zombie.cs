using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int InitialZombieSize = 0;
        private const int MeatFromKillingZombie = 10;

        public Zombie(string name, Point location)
            : base(name, location, Zombie.InitialZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return Zombie.MeatFromKillingZombie;
        }
    }
}
