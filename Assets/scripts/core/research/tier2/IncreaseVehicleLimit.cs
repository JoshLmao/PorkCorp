using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseVehicleLimit : ResearchBase
{
    public static string NAME { get { return "Increase Vehicle Limit"; } }

    public override string Name { get { return NAME; } }
    public override string Description { get { return $"Increases vehicles limit by {ModifyValue}!"; } }
    public override double Cost { get { return 5.0; } }

    public override ResearchType Type { get { return ResearchType.DistributionVehicleLimit; } }
    public override double ModifyValue { get { return 1.0; } }

    public override int AmountBought { get; protected set; }
    public override int MaxAmountAllowed { get { return 1; } }

    public IncreaseVehicleLimit(int tier, int order) : base(tier, order)
    {
    }
}