using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Queen : Parasite
    {
        private const int health = 30;
        private const int power = 1;
        private const int aggression = 1;

        public Queen(string id) 
            :base(id, UnitClassification.Psionic, Queen.health, Queen.power, Queen.aggression)
        {

        }
    }
}
