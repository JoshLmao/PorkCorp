using UnityEngine;

public class Van : ISellVehicle
{
    public static string NAME { get { return "Van"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.VAN_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public Van()
    {

    }

    public Van(int index)
    {
        VehicleIndex = index;
    }
}
