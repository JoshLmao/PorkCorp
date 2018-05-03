public class StackedSemiTruck : VehicleBase
{
    public static string NAME { get { return "StackedSemiTruck"; } }

    public override string Name { get { return NAME; } }
    public override double SellRate { get { return VehicleSellConstants.STACKED_SEMI_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public StackedSemiTruck(int index) : base(index)
    {

    }
}
