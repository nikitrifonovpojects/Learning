using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    class ZX8ParallelTwinTurbocharger : Turbocharger
    {
        private const decimal ZX8ParallelTwinPrice = 799;
        private const int ZX8ParallelTwinWeight = 3500;
        private const int ZX8ParallelTwinAcceleration = 15;
        private const int ZX8ParallelTwinTopSpeed = 60;
        private const TunningGradeType ZX8ParallelTwinGradeType = TunningGradeType.HighGrade;
        private const TurbochargerType ZX8ParallelTwinType = TurbochargerType.TwinTurbo;

        public ZX8ParallelTwinTurbocharger() 
            : base(ZX8ParallelTwinTurbocharger.ZX8ParallelTwinPrice, ZX8ParallelTwinTurbocharger.ZX8ParallelTwinWeight, ZX8ParallelTwinTurbocharger.ZX8ParallelTwinAcceleration, ZX8ParallelTwinTurbocharger.ZX8ParallelTwinTopSpeed, ZX8ParallelTwinTurbocharger.ZX8ParallelTwinGradeType, ZX8ParallelTwinTurbocharger.ZX8ParallelTwinType)
        {
        }
    }
}
