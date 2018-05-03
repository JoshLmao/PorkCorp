using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStackedSemi : ISellVehicle
{
    public static string NAME { get { return "DoubleStackedSemi"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.DOUBLE_STACKED_SEMI_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public DoubleStackedSemi()
    {

    }

    public DoubleStackedSemi(int index)
    {
        VehicleIndex = index;
    }
}

