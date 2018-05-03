public class Hangar : HouseBase
{
    public static string NAME { get { return "Hangar"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.HANGAR_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 15 * 1000; } }
}
