using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler
    {
        private const decimal EvolutionXPerformancePrice = 499;
        private const int EvolutionXPerformanceWeight = 4500;
        private const int EvolutionXPerformanceAcceleration = -5;
        private const int EvolutionXPerformanceTopSpeed = 40;
        private const TunningGradeType EvolutionXPerformanceGradeType = TunningGradeType.HighGrade;
        private const IntercoolerType EvolutionXPerformanceType = IntercoolerType.AirToLiquidIntercooler;

        public EvolutionXPerformanceIntercooler() 
            : base(EvolutionXPerformanceIntercooler.EvolutionXPerformancePrice, EvolutionXPerformanceIntercooler.EvolutionXPerformanceWeight, EvolutionXPerformanceIntercooler.EvolutionXPerformanceAcceleration, EvolutionXPerformanceIntercooler.EvolutionXPerformanceTopSpeed, EvolutionXPerformanceIntercooler.EvolutionXPerformanceGradeType, EvolutionXPerformanceIntercooler.EvolutionXPerformanceType)
        {
        }
    }
}
