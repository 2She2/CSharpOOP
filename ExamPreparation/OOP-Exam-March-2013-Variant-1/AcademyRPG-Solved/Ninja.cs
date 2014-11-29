using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public int AttackPoints { get; private set; }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                IncreaseAttackPoints(resource.Quantity);

                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                IncreaseAttackPoints(resource.Quantity * 2);

                return true;
            }

            return false;
        }

        private void IncreaseAttackPoints(int amountToIncrease)
        {
                this.AttackPoints += amountToIncrease;
        }

        public new bool IsDestroyed
        {
            get
            {
                return false;
            }
        }

        public int DefensePoints
        {
            get { throw new NotImplementedException(); }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPointsIndex = int.MinValue; ;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxHitPointsIndex)
                    {
                        maxHitPointsIndex = i;
                    }
                    
                }
            }

            return maxHitPointsIndex;
        }
    }
}
