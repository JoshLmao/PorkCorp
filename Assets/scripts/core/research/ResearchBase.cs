using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResearchBase : IResearch
{
    public int Tier { get; private set; }
    public int Order { get; private set; }

    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract double Cost { get; }
    public abstract double Value { get; }

    public ResearchBase(int tier, int order)
    {
        Tier = tier;
        Order = order;
    }
}
