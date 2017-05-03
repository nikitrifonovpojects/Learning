using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class FalkenAzenisTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int FalkenAzenisTireWeightInGrams = 7800;
        private const int FalkenAzenisTireAccelerationBonus = 3;
        private const int FalkenAzenisTireTopSpeedBonus = 0;
        private const decimal FalkenAzenisTirePriceInUSADollars = 359;
        private const TunningGradeType FalkenAzenisGradeType = TunningGradeType.LowGrade;
        private const TireType FalkenAzenisType = TireType.OffRoadTire;

        public FalkenAzenisTiresSet() 
            : base(FalkenAzenisTiresSet.FalkenAzenisTirePriceInUSADollars, FalkenAzenisTiresSet.FalkenAzenisTireWeightInGrams, FalkenAzenisTiresSet.FalkenAzenisTireAccelerationBonus, FalkenAzenisTiresSet.FalkenAzenisTireTopSpeedBonus, FalkenAzenisTiresSet.FalkenAzenisGradeType, FalkenAzenisTiresSet.FalkenAzenisType)
        {
        }
    }
}
