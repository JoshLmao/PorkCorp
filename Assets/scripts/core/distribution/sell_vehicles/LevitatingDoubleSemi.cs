﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatingDoubleSemi : ISellVehicle
{
    public static string NAME { get { return "LevitatingDoubleSemi"; } }

    public GameObject Prefab { get { return null; } }

    public string Name { get { return NAME; } }
    public double SellRate { get { return VehicleSellConstants.LEVITATING_DOUBLE_SEMI_BASE_SELL_VALUE; } }
    public double Cost { get { return 100.0; } }
    public int VehicleIndex { get; set; }

    public LevitatingDoubleSemi()
    {

    }

    public LevitatingDoubleSemi(int index)
    {
        VehicleIndex = index;
    }
}

