using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyVehiclesUIController : ListUIBase
{
    List<ISellVehicle> m_allVehicles = new List<ISellVehicle>()
    {
        new Estate(0),
        new Estate(1),
    };

    List<BuyVehicleUserControl> m_buyControls = new List<BuyVehicleUserControl>();

    public event Action<ISellVehicle> OnSelectVehicleToHire;

    protected override void Start()
    {
        base.Start();

        m_buyControls.Clear();

        UpdateVehicleList(m_allVehicles.Count);
    }

    protected override void EntryAdded(GameObject entry, int index)
    {
        ISellVehicle vehicle = m_allVehicles.FirstOrDefault(x => x.VehicleIndex == index);

        BuyVehicleUserControl uc = entry.GetComponent<BuyVehicleUserControl>();
        uc.DataContext = vehicle;

        uc.VehicleName = vehicle.Name;
        uc.SellRatePerMinute = vehicle.SellRate.ToString();
        uc.IconSprite = null;

        uc.OnBuyVehicle += OnBuyVehicle;

        m_buyControls.Add(uc);
    }

    private void OnBuyVehicle(ISellVehicle vehicle)
    {
        if (OnSelectVehicleToHire != null)
            OnSelectVehicleToHire.Invoke(vehicle);

        OnHideUI();
    }

    public override void OnHideUI()
    {
        base.OnHideUI();

        m_buyControls.Clear();
    }
}

