﻿using System;
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

    [SerializeField]
    List<GameObject> m_sellVehiclePrefabs;

    VehicleSpawnerController m_vehicleSpawner;

    public DistributionManager()
    {
        
    }

    private void Awake()
    {
        m_vehicleSpawner = FindObjectOfType<VehicleSpawnerController>();
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }

    public void SetStartVehicles()
    {
        BoughtVehicles = new List<ISellVehicle>()
        {
            new Estate(0),
        };
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

    public void SetVehicleLimit(int limit)
    {
        if (limit < VehicleLimit)
            return;

        VehicleLimit = limit;
    }
}
