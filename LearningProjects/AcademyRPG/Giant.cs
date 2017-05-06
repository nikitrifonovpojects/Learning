using System.Collections.Generic;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool gatherdStone;
        private int attackpoints;

        public Giant(string name, Point position, int owner = 0) 
            : base(name, position, owner)
        {
            this.HitPoints = 200;
            this.attackpoints = 150;
            this.gatherdStone = false;
        }

        public int AttackPoints
        {
            get
            {
                if (this.gatherdStone)
                {
                     return this.attackpoints + 100;
                }
                else
                {
                    return this.attackpoints;
                }
            }
            private set
            {
                this.attackpoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return 80;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
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
                this.gatherdStone = true;
                return true;
            }

            return false;
        }
    }
}
