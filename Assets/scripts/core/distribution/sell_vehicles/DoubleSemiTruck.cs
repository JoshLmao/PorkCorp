using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSemiTruck : ISellVehicle
{
    public static string NAME { get { return "DoubleSemiTruck"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.DOUBLE_SEMI_TRUCK_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public DoubleSemiTruck()
    {

    }

    public DoubleSemiTruck(int index)
    {
        VehicleIndex = index;
    }
}

