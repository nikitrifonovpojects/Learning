using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.ModelContracts;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITunningPart : IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        TunningGradeType GradeType { get; }
    }
}
