public class Truck : VehicleBase
{
    public static string NAME { get { return "Truck"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.TRUCK_BASE_SELL_VALUE; } }
    public override double Cost { get { return 500.0; } }
    public override int BaseCapacity { get { return 1; } }

    public Truck(int index) : base(index)
    {

    }
}
