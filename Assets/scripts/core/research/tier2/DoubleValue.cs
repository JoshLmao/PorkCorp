﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleValue : ResearchBase
{
    public override string Name { get { return "Double Value"; } }
    public override string Description { get { return "Double the value of your pork!"; } }
    public override double Cost { get { return 5.0; } }
    public override double Value { get { return 5.0; } }

    public DoubleValue(int tier, int order) : base(tier, order)
    {
    }
}