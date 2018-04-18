using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueResearch : ResearchBase
{
    public override string Name { get { return "Increase Value"; } }
    public override string Description { get { return "Increase pork value by 25%"; } }
    public override double Value { get { return 0.25; } }
    public override double Cost { get { return 0.40; } }

    public ValueResearch(int tier, int order) : base(tier, order)
    {
    }
}
