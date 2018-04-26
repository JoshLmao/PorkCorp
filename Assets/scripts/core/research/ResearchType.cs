using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ResearchType
{
    /// <summary>
    /// Increase recharging rate of fabricator click recharge
    /// </summary>
    FabricatorChargeRate,
    /// <summary>
    /// Increase the maximum charge of the fabricator by amount
    /// </summary>
    FabricatorMaxCharge,
    /// <summary>
    /// Increase the value by the amount (add value to additive multiplier)
    /// </summary>
    MoneyIncreaseValue,
    /// <summary>
    /// Increases the capacity of all houses by percentage amount (number between 0 - 100)
    /// </summary>
    HousingIncreaseCapacity,
}