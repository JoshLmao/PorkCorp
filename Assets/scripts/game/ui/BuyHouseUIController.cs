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

        UpdateList(HousingManager.ALL_HOUSES.Count - 1 - HouseToUpgrade.HouseIndex);
    }

    protected override void EntryAdded(GameObject entry, int index)
    {
        base.EntryAdded(entry, index);

        //Debug.Log($"{index} + {HouseToUpgrade.HouseIndex} + 1 = {index + HouseToUpgrade.HouseIndex + 1}");
        IHouse house = HousingManager.ALL_HOUSES.ElementAt(index + HouseToUpgrade.HouseIndex + 1);

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
