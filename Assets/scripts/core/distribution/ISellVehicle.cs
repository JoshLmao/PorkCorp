using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISellVehicle
{
    /// <summary>
    /// The total cost to buy/upgrade vehicle
    /// </summary>
    double Cost { get; }
    string Name { get; }
    /// <summary>
    /// The base capacity the vehicle can hold
    /// </summary>
    int BaseCapacity { get; }
    /// <summary>
    /// The current capacity of the vehicle
    /// </summary>
    int Capacity { get; set; }
    /// <summary>
    /// Rate it sells pork
    /// </summary>
    double SellRate { get; }
    /// <summary>
    /// The unique index of the vehicle. Starts at 0
    /// </summary>
    int VehicleIndex { get; set; }
}