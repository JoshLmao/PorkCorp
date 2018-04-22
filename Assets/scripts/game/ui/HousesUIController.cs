using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class HousesUIController : UIBase
{
    HousingManager m_housingManager;

    [SerializeField]
    BuyHouseUIController m_buyHouseCanvas;

    [SerializeField]
    UpgradeHouseUserControl m_houseOne;

    bool m_isListening;


    protected override void Awake()
    {
        base.Awake();

        m_housingManager = FindObjectOfType<HousingManager>();
    }

    private void Start()
    {
        UpdateHouses();
    }

    private void Update()
    {
        if (m_housingManager.BoughtHouses.Count >= 1)
        {
            IHouse house = m_housingManager.BoughtHouses.Values.ElementAt(0).GetComponent<HouseBase>().HouseInfo;
            m_houseOne.CurrentCapacity = house.CurrentCapacity;
        }
    }
        void UpdateHouses()
    {
        if (m_housingManager.BoughtHouses.Count >= 1)
        {
            IHouse house = m_housingManager.BoughtHouses.Values.ElementAt(0).GetComponent<HouseBase>().HouseInfo;
            m_houseOne.Name = house.Name;
            m_houseOne.TotalCapacity = house.TotalCapacity;
            m_houseOne.CurrentCapacity = house.CurrentCapacity;
            m_houseOne.DataContext = house;
            //m_houseOne.Icon = null;

            if (!m_isListening)
            {
                m_houseOne.OnUpgradeHouseClicked += OnUpgradeHouseClicked;
                m_isListening = true;
            }
        }
    }

    private void OnUpgradeHouseClicked(IHouse currentHouse)
    {
        BuyHouseUIController controller = m_buyHouseCanvas.GetComponent<BuyHouseUIController>();
        controller.HouseToUpgrade = currentHouse;
        controller.OnUpgradeHouse += OnUpgradeHouse;
        m_buyHouseCanvas.OnShowUI();
    }

    private void OnUpgradeHouse(IHouse prevHouse, IHouse upgradeToHouse)
    {
        m_buyHouseCanvas.GetComponent<BuyHouseUIController>().OnUpgradeHouse += OnUpgradeHouse;
        m_buyHouseCanvas.OnHideUI();

        m_housingManager.UpgradeHouse(prevHouse, upgradeToHouse);

        UpdateHouses();
    }

    public override void OnShowUI()
    {
        base.OnShowUI();

        UpdateHouses();
    }
}
