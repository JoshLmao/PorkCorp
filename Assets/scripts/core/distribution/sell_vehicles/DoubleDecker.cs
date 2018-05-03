using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDecker : ISellVehicle
{
    public static string NAME { get { return "DoubleDecker"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.DOUBLE_DECKER_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public DoubleDecker()
    {

    }

    public DoubleDecker(int index)
    {
        VehicleIndex = index;
    }
}