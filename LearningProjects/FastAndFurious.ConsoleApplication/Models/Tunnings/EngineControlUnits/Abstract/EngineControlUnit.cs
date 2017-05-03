﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.EngineControlUnits.Abstract
{
    public abstract class EngineControlUnit : Tunning, IEngineControlUnit, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        private EngineControlUnitType engineControlUnitType;

        public EngineControlUnit(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, EngineControlUnitType engineControlUnitType) 
            : base(price, weight, acceleration,topSpeed,gradeType)
        {
            this.engineControlUnitType = engineControlUnitType;
        }

        public EngineControlUnitType EngineControlUnitType
        {
            get
            {
                return this.engineControlUnitType;
            }
        }
    }
}
