public class OinkTower : HouseBase
{
    public static string NAME { get { return "OinkTower"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.OINK_TOWER_BASE_COST; } } 
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 10 * 1000; } }
}
