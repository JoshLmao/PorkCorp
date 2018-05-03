using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class HouseBase : IHouse
{
    public abstract string Name { get; }

    public int HouseIndex { get; set; }

    public abstract double BaseCost { get; }
    public abstract int BaseTotalCapacity { get; }
    public abstract double BasePassiveBreedInterval { get; }

    public int TotalCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public double CurrentPassiveBreedInterval { get; set; }

    public int PassiveBreedAmount { get; set; }

    public HouseBase()
    {
        TotalCapacity = BaseTotalCapacity;
        CurrentPassiveBreedInterval = BasePassiveBreedInterval;
    }

    public virtual void IncreaseTotalCapacity(int amount)
    {
        TotalCapacity += amount;
    }
}
