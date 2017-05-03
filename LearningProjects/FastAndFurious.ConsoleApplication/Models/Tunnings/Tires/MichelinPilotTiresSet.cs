﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class MichelinPilotTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int MichelinPilotTireWeightInGrams = 6500;
        private const int MichelinPilotTireAccelerationBonus = 7;
        private const int MichelinPilotTireTopSpeedBonus = 1;
        private const decimal MichelinPilotTirePriceInUSADollars = 1399;
        private const TunningGradeType MichelinPilotGradeType = TunningGradeType.LowGrade;
        private const TireType MichelinPilotType = TireType.OffRoadTire;

        public MichelinPilotTiresSet() 
            : base(MichelinPilotTiresSet.MichelinPilotTirePriceInUSADollars, MichelinPilotTiresSet.MichelinPilotTireWeightInGrams, MichelinPilotTiresSet.MichelinPilotTireAccelerationBonus, MichelinPilotTiresSet.MichelinPilotTireTopSpeedBonus, MichelinPilotTiresSet.MichelinPilotGradeType, MichelinPilotTiresSet.MichelinPilotType)
        {
        }
    }
}