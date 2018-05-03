public class LevitatingTruck : VehicleBase
{
    public static string NAME { get { return "LevitatingTruck"; } }

    public override string Name { get { return NAME; } }
    public override double SellRate { get { return VehicleSellConstants.LEVITATING_TRUCK_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public LevitatingTruck(int index) : base(index)
    {

    }
}