using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : ISellVehicle
{
    public GameObject Prefab { get { return null; } }

    public string Name { get { return "Truck"; } }
    public double SellRate { get { return 5.0; } }
    public double Cost { get { return 500.0; } }
    public int VehicleIndex { get; set; }
}
