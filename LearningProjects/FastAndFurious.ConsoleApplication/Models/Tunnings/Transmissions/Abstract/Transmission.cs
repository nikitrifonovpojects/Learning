using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public abstract class Transmission : Tunning
    {
        private readonly TransmissionType transmissionType;

        public Transmission(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TransmissionType transmissionType)
            : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.transmissionType = transmissionType;
        }

        public TransmissionType TransmissionType
        {
            get
            {
                return this.transmissionType;
            }
        }
    }
}
