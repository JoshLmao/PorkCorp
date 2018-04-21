using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sty : IHouse
{
    public static string NAME { get { return "Sty"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public int TotalCapacity { get { return 250; } }
    public int CurrentCapacity { get; set; }

    HouseBase m_prefab;

    public Sty()
    {

    }

    public void AddPigs(int amount)
    {
        CurrentCapacity += amount;
    }

    public void SetPrefabReference(HouseBase houseController)
    {
        m_prefab = houseController;
    }
}
