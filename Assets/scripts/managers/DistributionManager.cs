using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DistributionManager : MonoBehaviour
{
    public List<ISellVehicle> BoughtVehicles { get; private set; }

    int m_vehicleLimit = 2;
    public int VehicleLimit
    {
        get { return m_vehicleLimit; }
        set { m_vehicleLimit = value; }
    }

    int m_totalIncreaseAmountPercent = 0;
    public int TotalIncreaseAmountPercent
    {
        get { return m_totalIncreaseAmountPercent; }
        set { m_totalIncreaseAmountPercent = value; }
    }

    [SerializeField]
    List<GameObject> m_sellVehiclePrefabs;

    public DistributionManager()
    {
        
    }

    private void Awake()
    {
    }

    private void Start ()
    {
    }

    private void Update ()
    {
        
    }

    public void BuyVehicle(ISellVehicle sellVehicle)
    {
        if (BoughtVehicles == null)
        {
            Debug.Log("Unable to add sell vehicle. BoughtVehicles is null");
            return;
        }

        BoughtVehicles.Add(sellVehicle);
    }

    public void SetVehicles(List<ISellVehicle> boughtVehicles)
    {
        if(boughtVehicles == null)
        {
            BoughtVehicles = new List<ISellVehicle>()
            {
                new Estate(0),
            };
        }
        else
        {
            BoughtVehicles = boughtVehicles;
        }
    }

    public void SetVehicleLimit(int limit)
    {
        if (limit < VehicleLimit)
            return;

        VehicleLimit = limit;
    }

    public void IncreaseVehicleCapacity(int percentageValue)
    {
        TotalIncreaseAmountPercent += percentageValue;
        foreach(ISellVehicle vehicle in BoughtVehicles)
        {
            int incrementAmount = (vehicle.Capacity / 100) * percentageValue;
            vehicle.Capacity += incrementAmount;
        }
    }

    public void IncreaseVehicleLimit(int value)
    {
        VehicleLimit += value;
    }

    public void IncreaseVehicleSellRates(int percentValue)
    {
        foreach(ISellVehicle vehicle in BoughtVehicles)
        {
            double incSellRateValue = (vehicle.SellRate / 100) * percentValue;
            //vehicle.SellRate += incSellRateValue;
        }
    }
}
