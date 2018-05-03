public abstract class VehicleBase : ISellVehicle
{
    public abstract string Name { get; }
    public abstract double SellRate { get; }
    public abstract double Cost { get; }
    public abstract int BaseCapacity { get; }

    public int VehicleIndex { get; set; }
    public int Capacity { get; set; }

    public VehicleBase()
    {
        Init();
    }

    public VehicleBase(int index)
    {
        VehicleIndex = index;
        Init();
    }

    protected virtual void Init()
    {
        Capacity = BaseCapacity;
    }

    public virtual void IncreaseCapacity(int amount)
    {
        Capacity += amount;
    }
}