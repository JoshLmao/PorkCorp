using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHouse
{
    /// <summary>
    /// The unique name of the house
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The base cost to buy the house
    /// </summary>
    double BaseCost { get; }
    /// <summary>
    /// The total number of pigs that can be inside the house
    /// </summary>
    int TotalCapacity { get; }
    /// <summary>
    /// The number of pigs currently inside this house
    /// </summary>
    int CurrentCapacity { get; set; }
    /// <summary>
    /// The rate that the pigs will breed at in this house
    /// </summary>
    double PigsPerSecond { get; set; }
    int HouseIndex { get; set; }
}