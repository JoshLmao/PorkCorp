using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : ISellVehicle
{
    public static string NAME { get { return "Bus"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.BUS_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public Bus()
    {

    }

    public Bus(int index)
    {
        VehicleIndex = index;
    }
}
