using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int AttackPointsForGatherStone = 100;
        private bool isGatherStone = false;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner) //  && availableTargets[i].Owner != 0
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                IncreaseAttackPoints(AttackPointsForGatherStone);

                return true;
            }

            return false;
        }

        private void IncreaseAttackPoints(int amountToIncrease)
        {
            if (!isGatherStone)
            {
                isGatherStone = true;
                this.AttackPoints += amountToIncrease;
            }
        }
    }
}
