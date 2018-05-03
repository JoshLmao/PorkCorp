public abstract class VehicleBase : ISellVehicle
{
    public abstract string Name { get; }
    public abstract double Cost { get; }

    public int VehicleIndex { get; set; }

    public abstract int BaseCapacity { get; }
    public abstract double BaseSellRate { get; }

    public int Capacity { get; set; }
    public double SellRate { get; set; }

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

    public virtual void IncreaseCapacity(double percentValue)
    {
        int incAmount = (int)(Capacity / 100 * percentValue);
        Capacity += incAmount;
    }

    public virtual void IncreaseSellRate(double percentValue)
    {
        int incAmount = (int)(BaseSellRate / 100 * percentValue);
        SellRate += incAmount;
    }
}