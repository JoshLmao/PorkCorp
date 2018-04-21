using System;
using System.Linq;
using UnityEngine;

public class BuyHouseUIController : ListUIBase
{
    HousingManager m_housingManager;

    public IHouse HouseToUpgrade { get; set; }

    public event Action<IHouse, IHouse> OnUpgradeHouse;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        UpdateList(HousingManager.ALL_HOUSES.Count);
    }

    protected override void EntryAdded(GameObject entry, int index)
    {
        base.EntryAdded(entry, index);

        IHouse house = HousingManager.ALL_HOUSES.ElementAt(index);

        BuyHouseUserControl uc = entry.GetComponent<BuyHouseUserControl>();
        uc.Name = house.Name;
        uc.Cost = house.BaseCost;
        uc.DataContext = house;
        uc.OnBuyHouse += OnBuyHouse;
    }

    private void OnBuyHouse(IHouse upgradeToHouse)
    {
        upgradeToHouse.HouseIndex = HouseToUpgrade.HouseIndex;
        OnUpgradeHouse?.Invoke(HouseToUpgrade, upgradeToHouse);
    }
}
