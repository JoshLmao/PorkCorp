public class DoubleDecker : VehicleBase
{
    public static string NAME { get { return "DoubleDecker"; } }

    public override string Name { get { return NAME; } }
    public override double SellRate { get { return VehicleSellConstants.DOUBLE_DECKER_BASE_SELL_VALUE; } }
    public override double Cost { get { return 100.0; } }
    public override int BaseCapacity { get { return 1; } }

    public DoubleDecker(int index) : base(index)
    {

    }
}