using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleValue : ResearchBase
{
    public static string NAME { get { return "Double Value"; } }

    public override string Name { get { return NAME; } }
    public override string Description { get { return "Double the value of your pork!"; } }
    public override double Cost { get { return 5.0; } }

    public override double ModifyValue { get { return 5.0; } }

    public override int AmountBought { get; protected set; }
    public override int MaxAmountAllowed { get { return 10; } }

    public DoubleValue(int tier, int order) : base(tier, order)
    {
    }
}
