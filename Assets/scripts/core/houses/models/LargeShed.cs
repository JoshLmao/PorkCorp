public class LargeShed : HouseBase
{
    public static string NAME { get { return "Large Shed"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.LARGE_SHED_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 500; } }
    public override double BasePassiveBreedInterval { get { return 40 * 1000; } }
}
