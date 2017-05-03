using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class VortexR35SequentialTurbocharger : Turbocharger
    {
        private const decimal VortexR35SequentialPrice = 699;
        private const int VortexR35SequentialWeight = 3900;
        private const int VortexR35SequentialAcceleration = 10;
        private const int VortexR35SequentialTopSpeed = 85;
        private const TunningGradeType VortexR35SequentialGradeType = TunningGradeType.HighGrade;
        private const TurbochargerType VortexR35SequentialType = TurbochargerType.SequentialTurbo;

        public VortexR35SequentialTurbocharger() 
            : base(VortexR35SequentialTurbocharger.VortexR35SequentialPrice, VortexR35SequentialTurbocharger.VortexR35SequentialWeight, VortexR35SequentialTurbocharger.VortexR35SequentialAcceleration, VortexR35SequentialTurbocharger.VortexR35SequentialTopSpeed, VortexR35SequentialTurbocharger.VortexR35SequentialGradeType, VortexR35SequentialTurbocharger.VortexR35SequentialType)
        {
        }
    }
}
