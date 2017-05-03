using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class RemusExhaust : Exhaust
    {
        private const decimal RemusPrice = 679;
        private const int RemusWeight = 11500;
        private const int RemusAcceleration = 8;
        private const int RemusTopSpeed = 32;
        private const TunningGradeType RemusGradeType = TunningGradeType.MidGrade;
        private const ExhaustType RemusType = ExhaustType.StainlessSteel;

        public RemusExhaust() 
            : base(RemusExhaust.RemusPrice, RemusExhaust.RemusWeight, RemusExhaust.RemusAcceleration, RemusExhaust.RemusTopSpeed, RemusExhaust.RemusGradeType, RemusExhaust.RemusType)
        {
        }
    }
}
