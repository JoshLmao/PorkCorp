public class PorkHouse : HouseBase
{
    public static string NAME { get { return "PorkHouse"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.PORKHOUSE_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 25 * 1000; } }
}