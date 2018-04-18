using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseExpansion : ResearchBase
{
    public override string Name { get { return "House Expansion"; } }
    public override string Description { get { return "Expand your houses by x%"; } }
    public override double Cost { get { return 10.0; } }
    public override double Value { get { return 10.0; } }

    public HouseExpansion(int tier, int order) : base(tier, order)
    {
    }
}
