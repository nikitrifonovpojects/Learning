using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class BorlaExhaust : Exhaust
    {
        private const decimal BorlaPrice = 1299;
        private const int BorlaWeight = 14600;
        private const int BorlaAcceleration = 12;
        private const int BorlaTopSpeed = 40;
        private const TunningGradeType BorlaGradeType = TunningGradeType.HighGrade;
        private const ExhaustType BorlaType = ExhaustType.CeramicCoated;

        public BorlaExhaust() 
            : base(BorlaExhaust.BorlaPrice, BorlaExhaust.BorlaWeight, BorlaExhaust.BorlaAcceleration, BorlaExhaust.BorlaTopSpeed, BorlaExhaust.BorlaGradeType, BorlaExhaust.BorlaType)
        {
        }
    }
}
