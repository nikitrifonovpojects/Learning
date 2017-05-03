using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler
    {
        private const decimal ViperGeniePrice = 289;
        private const int ViperGenieWeight = 5300;
        private const int ViperGenieAcceleration = 0;
        private const int ViperGenieTopSpeed = 25;
        private const TunningGradeType ViperGenieGradeType = TunningGradeType.MidGrade;
        private const IntercoolerType ViperGenieType = IntercoolerType.ChargeAirIntercooler;

        public ViperGenieIntercooler() 
            : base(ViperGenieIntercooler.ViperGeniePrice, ViperGenieIntercooler.ViperGenieWeight, ViperGenieIntercooler.ViperGenieAcceleration, ViperGenieIntercooler.ViperGenieTopSpeed, ViperGenieIntercooler.ViperGenieGradeType, ViperGenieIntercooler.ViperGenieType)
        {
        }
    }
}
