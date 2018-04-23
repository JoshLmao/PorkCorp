using System;
using System.Linq;
using UnityEngine;

public class BuyHouseUIController : ListUIBase
{
    HousingManager m_housingManager;

    public IHouse HouseToUpgrade { get; set; }
    /// <summary>
    /// The index in the row of houses the current house is
    /// </summary>
    public int HouseIndex { get; set;}

    public event Action<IHouse, IHouse> OnUpgradeHouse;
    public event Action<IHouse> OnBuildHouse;

    int m_startFromIndex = 0;

    public override void OnShowUI()
    {
        base.OnShowUI();

        //Index of list of all houses to start from. Eg, 0 draws all houses
        m_startFromIndex = HouseToUpgrade != null ? HousingManager.ALL_HOUSES.IndexOf(HousingManager.ALL_HOUSES.FirstOrDefault(x => x.Name == HouseToUpgrade.Name)) : 0;
        UpdateList(HousingManager.ALL_HOUSES.Count - m_startFromIndex - 1);
    }

    protected override void EntryAdded(GameObject entry, int index)
    {
        base.EntryAdded(entry, index);

        //+ 1 to not draw itself
        IHouse house = HousingManager.ALL_HOUSES.ElementAt(m_startFromIndex + index + 1);

        BuyHouseUserControl uc = entry.GetComponent<BuyHouseUserControl>();
        uc.Name = house.Name;
        uc.Cost = house.BaseCost;
        uc.DataContext = house;
        uc.OnBuyHouse += OnBuyHouse;
    }

    private void OnBuyHouse(IHouse upgradeToHouse)
    {
        if (HouseToUpgrade != null)
        {
            upgradeToHouse.HouseIndex = HouseToUpgrade.HouseIndex;
            OnUpgradeHouse?.Invoke(HouseToUpgrade, upgradeToHouse);
        }
        else
        {
            upgradeToHouse.HouseIndex = HouseIndex;
            OnBuildHouse?.Invoke(upgradeToHouse);
        }
    }
}
