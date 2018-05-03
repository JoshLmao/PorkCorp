public class Bungalow : HouseBase
{
    public static string NAME { get { return "Bungalow"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.BUNGALOW_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 1000; } }
}
