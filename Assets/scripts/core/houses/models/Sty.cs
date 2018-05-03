public class Sty : HouseBase
{
    public static string NAME { get { return "Sty"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return 1.0; } }
    public override int BaseTotalCapacity { get { return 250; } }
    public override double BasePassiveBreedInterval { get { return 45 * 1000; } }
}
