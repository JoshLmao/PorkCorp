using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoughtVehiclesUIController : ListUIBase
{
    [SerializeField]
    GameObject m_buyCanvas;

    DistributionManager m_distributionManager;

    /// <summary>
    /// List of all instantiated UI buttons
    /// </summary>
    List<BoughtVehiclesUserControl> m_boughtVehiclesUCs = new List<BoughtVehiclesUserControl>();

    protected override void Awake()
    {
        base.Awake();

        m_distributionManager = FindObjectOfType<DistributionManager>();
    }

    protected override void Start()
    {
        base.Start();
        m_boughtVehiclesUCs.Clear();
        UpdateList(m_distributionManager.VehicleLimit);
    }

    protected override void Update()
    {

    }

    protected override void EntryAdded(GameObject entry, int index)
    {
        //Find dto that matches current index
        ISellVehicle foundVehicle = null;
        if (m_distributionManager.BoughtVehicles != null && m_distributionManager.BoughtVehicles.Count > 0)
            foundVehicle = m_distributionManager.BoughtVehicles.FirstOrDefault(x => x.VehicleIndex == index);

        if (foundVehicle != null)
            entry.name = foundVehicle.Name;

        BoughtVehiclesUserControl uc = entry.GetComponent<BoughtVehiclesUserControl>();
        uc.DataContext = foundVehicle;

        uc.IsBought = foundVehicle != null;
        uc.VehicleName = foundVehicle != null ? foundVehicle.Name : "?";
        uc.IconSprite = null;
        uc.SellRatePerMinute = foundVehicle != null ? foundVehicle.SellRate.ToString() : "0.0";

        uc.OnHireButtonClicked += OnHireNewVehicleBtnClicked;
        uc.OnUpgradeBtnClicked += OnUpgradeBtnClicked;

        m_boughtVehiclesUCs.Add(uc);
    }

    private void OnUpgradeBtnClicked(ISellVehicle upgradeVehicle)
    {
        m_buyCanvas.gameObject.SetActive(true);
    }

    private void OnHireNewVehicleBtnClicked(ISellVehicle vehicle)
    {
        //Hire new vehicle to show UI
        m_buyCanvas.GetComponent<BuyVehiclesUIController>().OnSelectVehicleToHire += OnHireSelectedVehicle;
        m_buyCanvas.gameObject.SetActive(true);
    }

    private void OnHireSelectedVehicle(ISellVehicle vehicle)
    {
        //Finished selecting which vehicle to buy
        m_buyCanvas.GetComponent<BuyVehiclesUIController>().OnSelectVehicleToHire -= OnHireSelectedVehicle;

        m_distributionManager.BuyVehicle(vehicle);
        UpdateList(m_distributionManager.VehicleLimit);
    }
}
