public class DoubleSemiTruck : VehicleBase
{
    public static string NAME { get { return "DoubleSemiTruck"; } }

    public override string Name { get { return NAME; } }
    public override double SellRate { get { return VehicleSellConstants.DOUBLE_SEMI_TRUCK_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public DoubleSemiTruck(int index) : base(index)
    {

    }
}

