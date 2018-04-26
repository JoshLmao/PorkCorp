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

    public abstract int AmountBought { get; protected set; }
    public abstract int MaxAmountAllowed { get; }

    public abstract double ModifyValue { get; }
    public abstract ResearchType Type { get; }

    public ResearchBase(int tier, int order)
    {
        Tier = tier;
        Order = order;

        AmountBought = 0;
    }

    public void Buy()
    {
        AmountBought++;
    }

    public virtual void SetLoadedValues(int amountBought)
    {
        AmountBought = amountBought;
    }
}
