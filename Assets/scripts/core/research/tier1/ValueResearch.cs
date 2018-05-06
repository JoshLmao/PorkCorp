using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueResearch : ResearchBase
{
    public static string NAME { get { return "Increase Value"; } }

    public override string Name { get { return NAME; } }
    public override string Description { get { return $"Increase pork value by {ModifyValue * 100}%"; } }
    public override double BaseCost { get { return 0.40; } }

    public override ResearchType Type { get { return ResearchType.MoneyIncreaseValue; } }
    public override double ModifyValue { get { return 0.25; } }

    public override int AmountBought { get; protected set; }
    public override int MaxAmountAllowed { get { return 10; } }

    public ValueResearch(int tier, int order) : base(tier, order)
    {
    }
}
