public class ThePorkopolis : HouseBase
{
    public static string NAME { get { return "The Porkopolis"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.PORKOPOLIS_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 5 * 1000; } }
}
