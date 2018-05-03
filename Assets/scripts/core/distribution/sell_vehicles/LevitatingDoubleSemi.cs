public class LevitatingDoubleSemi : VehicleBase
{
    public static string NAME { get { return "LevitatingDoubleSemi"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.LEVITATING_DOUBLE_SEMI_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public LevitatingDoubleSemi(int index) : base(index)
    {

    }
}

