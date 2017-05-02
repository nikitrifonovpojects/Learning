using System.Globalization;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public abstract class AbstractSpeciality : Specialty
    {
        protected abstract string GetFormatValue();
        
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.GetFormatValue());
        }
    }
}
