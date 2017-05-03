using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class BMShortShifter : Transmission
    {
        private const decimal BMShortShifterPrice = 2799;
        private const int BMShortShifterWeight = 5700;
        private const int BMShortShifterAcceleration = 28;
        private const int BMShortShifterTopSpeed = 0;
        private const TunningGradeType BMShortShifterGradeType = TunningGradeType.HighGrade;
        private const TransmissionType BMShortShifterType = TransmissionType.ManualShortShifter;

        public BMShortShifter() 
            : base(BMShortShifter.BMShortShifterPrice, BMShortShifter.BMShortShifterWeight, BMShortShifter.BMShortShifterAcceleration, BMShortShifter.BMShortShifterTopSpeed, BMShortShifter.BMShortShifterGradeType, BMShortShifter.BMShortShifterType)
        {
        }
    }
}
