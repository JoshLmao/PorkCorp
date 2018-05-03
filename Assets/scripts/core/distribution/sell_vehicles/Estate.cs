using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estate : ISellVehicle
{
    public static string NAME { get { return "Estate"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.ESTATE_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public Estate()
    {

    }

    public Estate(int index)
    {
        VehicleIndex = index;
    }
}
