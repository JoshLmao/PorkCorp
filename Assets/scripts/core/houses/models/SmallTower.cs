public class SmallTower : HouseBase
{
    public static string NAME { get { return "SmallTower"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.SMALL_TOWER_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 15 * 1000; } }
}
