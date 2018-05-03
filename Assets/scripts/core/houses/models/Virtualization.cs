public class Virtualization : HouseBase
{
    public static string NAME { get { return "Virtualization"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.VIRTUALIZATION_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 2.5 * 1000; } }
}
