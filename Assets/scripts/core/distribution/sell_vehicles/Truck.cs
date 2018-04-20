using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : ISellVehicle
{
    public static string NAME { get { return "Truck"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return 5.0; } }
    public double Cost { get { return 500.0; } }
    public int VehicleIndex { get; set; }

    public Truck() { }

    public Truck(int index)
    {
        VehicleIndex = index;
    }
}
