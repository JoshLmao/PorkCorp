public class Estate : VehicleBase
{
    public static string NAME { get { return "Estate"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.ESTATE_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public Estate(int index) : base(index)
    {

    }
}
