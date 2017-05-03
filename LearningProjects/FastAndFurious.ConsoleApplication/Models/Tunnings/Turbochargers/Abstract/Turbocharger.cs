using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract
{
    public abstract class Turbocharger : Tunning, ITurbocharger, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private readonly TurbochargerType turbochargerType;

        public Turbocharger(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TurbochargerType turbochargerType) 
            :base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.turbochargerType = turbochargerType;
        }

        public TurbochargerType TurbochargerType
        {
            get
            {
                return this.turbochargerType;
            }
        }
    }
}
