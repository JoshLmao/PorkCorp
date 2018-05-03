public class Bus : VehicleBase
{
    public static string NAME { get { return "Bus"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.BUS_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public Bus(int index) : base(index)
    {

    }
}
