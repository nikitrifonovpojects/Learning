using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class TWMPerformanceTransmission : Transmission
    {
        private const decimal TWMPerformanceTransmissionPrice = 1599;
        private const int TWMPerformanceTransmissionWeight = 4799;
        private const int TWMPerformanceTransmissionAcceleration = 15;
        private const int TWMPerformanceTransmissionTopSpeed = 0;
        private const TunningGradeType TWMPerformanceTransmissionGradeType = TunningGradeType.LowGrade;
        private const TransmissionType TWMPerformanceTransmissionType = TransmissionType.SemiManualShifter;

        public TWMPerformanceTransmission() 
            : base(TWMPerformanceTransmission.TWMPerformanceTransmissionPrice, TWMPerformanceTransmission.TWMPerformanceTransmissionWeight, TWMPerformanceTransmission.TWMPerformanceTransmissionAcceleration, TWMPerformanceTransmission.TWMPerformanceTransmissionTopSpeed, TWMPerformanceTransmission.TWMPerformanceTransmissionGradeType, TWMPerformanceTransmission.TWMPerformanceTransmissionType)
        {
        }
    }
}
