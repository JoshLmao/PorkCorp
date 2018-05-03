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
    /// The base sell rate the vehicle sells
    /// </summary>
    double BaseSellRate { get; }
    /// <summary>
    /// The current sell rate
    /// </summary>
    double SellRate { get; set; }
    /// <summary>
    /// The unique index of the vehicle. Starts at 0
    /// </summary>
    int VehicleIndex { get; set; }

    /// <summary>
    /// Increases the capacity of the vehicle by a percentage
    /// </summary>
    /// <param name="amount"></param>
    void IncreaseCapacity(double percent);
    /// <summary>
    /// Increases the sell rate by a percentage
    /// </summary>
    /// <param name="amount"></param>
    void IncreaseSellRate(double percent);
}