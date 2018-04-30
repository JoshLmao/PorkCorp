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

    [SerializeField]
    UpgradeHouseUserControl m_houseTwo;

    [SerializeField]
    UpgradeHouseUserControl m_houseThree;

    [SerializeField]
    UpgradeHouseUserControl m_houseFour;

    bool m_isListening;

    protected override void Awake()
    {
        base.Awake();

        m_housingManager = FindObjectOfType<HousingManager>();

        UpdateHouses();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (m_housingManager.BoughtHouses.Count >= 1)
        {
            IHouse house = m_housingManager.BoughtHouses.Values.ElementAt(0).GetComponent<HouseController>().HouseInfo;
            m_houseOne.CurrentCapacity = house.CurrentCapacity;
        }
    }

    void UpdateHouses()
    {
        SetUI(0, m_houseOne);
        SetUI(1, m_houseTwo);
        SetUI(2, m_houseThree);
        SetUI(3, m_houseFour);
    }

    void SetUI(int houseIndex, UpgradeHouseUserControl uc)
    {
        //Unbind incase it already is
        uc.OnUpgradeHouseClicked -= OnUpgradeHouseClicked;
        uc.OnBuildHouseClicked -= OnBuildHouseClicked;

        if(m_housingManager.BoughtHouses.Count > houseIndex)
        {
            GameObject element = m_housingManager.BoughtHouses.Values.ElementAt(houseIndex);
            IHouse house = element.GetComponent<HouseController>().HouseInfo;
            if (house != null)
            {
                uc.Name = house.Name;
                uc.TotalCapacity = house.TotalCapacity;
                uc.CurrentCapacity = house.CurrentCapacity;
                uc.DataContext = house;
            }
        }

        uc.HouseIndex = houseIndex;
        uc.OnUpgradeHouseClicked += OnUpgradeHouseClicked;
        uc.OnBuildHouseClicked += OnBuildHouseClicked;
    }

    private void OnBuildHouseClicked(int houseIndex)
    {
        if (houseIndex < 0)
            return;

        BuyHouseUIController controller = m_buyHouseCanvas.GetComponent<BuyHouseUIController>();
        controller.HouseIndex = houseIndex;
        controller.OnBuildHouse += OnBuildHouse;
        m_buyHouseCanvas.OnSetUI(false);
    }

    private void OnUpgradeHouseClicked(IHouse currentHouse)
    {
        BuyHouseUIController controller = m_buyHouseCanvas.GetComponent<BuyHouseUIController>();
        controller.HouseToUpgrade = currentHouse;
        controller.OnUpgradeHouse += OnUpgradeHouse;
        m_buyHouseCanvas.OnSetUI(false);
    }

    private void OnBuildHouse(IHouse upgradeToHouse)
    {
        m_buyHouseCanvas.GetComponent<BuyHouseUIController>().OnBuildHouse -= OnBuildHouse;
        m_buyHouseCanvas.OnSetUI(false);

        m_housingManager.AddHouse(upgradeToHouse);

        UpdateHouses();
    }

    private void OnUpgradeHouse(IHouse prevHouse, IHouse upgradeToHouse)
    {
        m_buyHouseCanvas.GetComponent<BuyHouseUIController>().OnUpgradeHouse -= OnUpgradeHouse;
        m_buyHouseCanvas.OnSetUI(false);

        m_housingManager.UpgradeHouse(prevHouse, upgradeToHouse);

        UpdateHouses();
    }

    public override void OnToggleUI()
    {
        base.OnToggleUI();

        UpdateHouses();
    }
}
