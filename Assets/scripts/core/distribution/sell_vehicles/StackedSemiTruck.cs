using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackedSemiTruck : ISellVehicle
{
    public static string NAME { get { return "StackedSemiTruck"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.STACKED_SEMI_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public StackedSemiTruck()
    {

    }

    public StackedSemiTruck(int index)
    {
        VehicleIndex = index;
    }
}
