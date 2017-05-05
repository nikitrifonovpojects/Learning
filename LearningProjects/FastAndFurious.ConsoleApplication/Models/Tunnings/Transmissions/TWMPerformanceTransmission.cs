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

        public TWMPerformanceTransmission() 
            : base(TWMPerformanceTransmissionPrice, TWMPerformanceTransmissionWeight, TWMPerformanceTransmissionAcceleration, TWMPerformanceTransmissionTopSpeed, TunningGradeType.LowGrade, TransmissionType.SemiManualShifter)
        {
        }
    }
}
