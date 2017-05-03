using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    class HurstCompetitionManualShifter : Transmission
    {
        private const decimal HurstCompetitionManualShifterPrice = 1999;
        private const int HurstCompetitionManualShifterWeight = 6000;
        private const int HurstCompetitionManualShifterAcceleration = 20;
        private const int HurstCompetitionManualShifterTopSpeed = 0;
        private const TunningGradeType HurstCompetitionManualShifterGradeType = TunningGradeType.MidGrade;
        private const TransmissionType HurstCompetitionManualShifterType = TransmissionType.StockShifter;

        public HurstCompetitionManualShifter() 
            : base(HurstCompetitionManualShifter.HurstCompetitionManualShifterPrice, HurstCompetitionManualShifter.HurstCompetitionManualShifterWeight, HurstCompetitionManualShifter.HurstCompetitionManualShifterAcceleration, HurstCompetitionManualShifter.HurstCompetitionManualShifterTopSpeed, HurstCompetitionManualShifter.HurstCompetitionManualShifterGradeType, HurstCompetitionManualShifter.HurstCompetitionManualShifterType)
        {
        }
    }
}
