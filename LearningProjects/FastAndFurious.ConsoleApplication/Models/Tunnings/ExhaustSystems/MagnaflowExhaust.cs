using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class MagnaflowExhaust : Exhaust
    {
        private const decimal MagnaflowPrice = 379;
        private const int MagnaflowWeight = 12800;
        private const int MagnaflowAcceleration = 5;
        private const int MagnaflowTopSpeed = 25;
        private const TunningGradeType MagnaflowGradeType = TunningGradeType.LowGrade;
        private const ExhaustType MagnaflowType = ExhaustType.NickelChromePlated;

        public MagnaflowExhaust() 
            : base(MagnaflowExhaust.MagnaflowPrice, MagnaflowExhaust.MagnaflowWeight, MagnaflowExhaust.MagnaflowAcceleration, MagnaflowExhaust.MagnaflowTopSpeed, MagnaflowExhaust.MagnaflowGradeType, MagnaflowExhaust.MagnaflowType)
        {
        }
    }
}
