using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IGatherer, IFighter
    {
        private int attackPoints = 0;

        public Ninja(string name, Point position, int owner) 
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var bestTarget = availableTargets.OrderBy(x => x.HitPoints).ToList();

            for (int i = 0; i < bestTarget.Count; i++)
            {
                if (bestTarget[i].Owner != this.Owner && bestTarget[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
