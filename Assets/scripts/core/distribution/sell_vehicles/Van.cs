public class Van : VehicleBase
{
    public static string NAME { get { return "Van"; } }

    public override string Name { get { return NAME; } }
    public override double BaseSellRate { get { return VehicleSellConstants.VAN_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public Van(int index) : base(index)
    {

    }
}
