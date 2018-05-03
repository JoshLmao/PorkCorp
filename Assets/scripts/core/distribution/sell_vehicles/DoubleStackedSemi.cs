public class DoubleStackedSemi : VehicleBase
{
    public static string NAME { get { return "DoubleStackedSemi"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.DOUBLE_STACKED_SEMI_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public DoubleStackedSemi(int index) : base(index)
    {

    }
}

