public class Pigosseum : HouseBase
{
    public static string NAME { get { return "Pigosseum"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.PIGOSSEUM_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 7 * 1000; } }
}
