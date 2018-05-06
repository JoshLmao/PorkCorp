using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricatorRecharge : ResearchBase
{
    public static string NAME { get { return "Better Recharging"; } }

    public override string Name { get { return NAME; } }
    public override string Description { get { return $"Increases Fabricator recharge rate by {ModifyValue}%"; } }
    public override double BaseCost { get { return 0.40; } }

    public override int AmountBought { get; protected set; }
    public override int MaxAmountAllowed { get { return 10; } }

    public override ResearchType Type { get { return ResearchType.FabricatorChargeRate; } }
    public override double ModifyValue { get { return 10; } }

    public FabricatorRecharge(int tier, int order) : base(tier, order)
    {
    }
}
