public class Library : HouseBase
{
    public static string NAME { get { return "Library"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return HouseCostConstants.LIBRARY_BASE_COST; } }
    public override int BaseTotalCapacity { get { return 250; } }
}