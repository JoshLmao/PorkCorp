using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHouse
{
    /// <summary>
    /// The total number of pigs that can be inside the house
    /// </summary>
    int TotalCapacity { get; }
    /// <summary>
    /// The number of pigs currently inside this house
    /// </summary>
    int CurrentCapacity { get; }
    /// <summary>
    /// The rate that the pigs will breed at in this house
    /// </summary>
    double PigsPerSecond { get; set; }

    void AddPigs(int amount);
}