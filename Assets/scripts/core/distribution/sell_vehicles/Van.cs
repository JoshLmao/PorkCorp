﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : ISellVehicle
{
    public GameObject Prefab { get { return null; } }

    public string Name { get { return "Estate"; } }
    public double SellRate { get { return 1.0; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }
}