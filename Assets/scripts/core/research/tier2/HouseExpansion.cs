using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseExpansion : ResearchBase
{
    public static string NAME { get { return "House Expansion"; } }

    public override string Name { get { return NAME; } }
    public override string Description { get { return $"Expand your houses by {ModifyValue}%"; } }
    public override double Cost { get { return 10.0; } }

    public override ResearchType Type { get { return ResearchType.HousingIncreaseCapacity; } }
    public override double ModifyValue { get { return 10.0; } }

    public override int AmountBought { get; protected set; }
    public override int MaxAmountAllowed { get { return 10; } }

    public HouseExpansion(int tier, int order) : base(tier, order)
    {
    }
}
