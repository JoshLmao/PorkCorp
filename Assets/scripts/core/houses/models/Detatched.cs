public class Detatched : HouseBase
{
    public static string NAME { get { return "Detatched"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.DETATCHED_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 2500; } }
    public override double BasePassiveBreedInterval { get { return 30 * 1000; } }
}
