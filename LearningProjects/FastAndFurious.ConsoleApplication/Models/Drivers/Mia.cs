﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Mia : Driver
    {
        private const string MiaName = "Mia";
        private const GenderType DriverGender = GenderType.Female;

        public Mia() 
            : base(MiaName, GenderType.Female)
        {
        }
    }
}
