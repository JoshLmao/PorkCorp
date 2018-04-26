using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HousingManager : MonoBehaviour
{
    public static List<IHouse> ALL_HOUSES = new List<IHouse>()
    {
        new Sty(),
        new LargeShed(),
        new Bungalow(),
        new Detatched(),
        new Mansion(),
    };

    public Dictionary<int, GameObject> BoughtHouses { get; private set; }

    [SerializeField]
    GameObject[] m_housePrefabs;

    [SerializeField]
    Transform m_housingParent;

    [SerializeField]
    float m_paddingWidth = 0f;

    MoneyManager m_moneyManager;

    const int MAX_HOUSES = 4;

    public HousingManager()
    {
        BoughtHouses = new Dictionary<int, GameObject>();
    }

    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }

    /// <summary>
    /// Adds the starting house configuration for a new farm
    /// </summary>
    public void AddNewStartHouses()
    {
        if (BoughtHouses.Count >= MAX_HOUSES)
            return;

        if(BoughtHouses != null && BoughtHouses.Count > 0)
            BoughtHouses.Clear();

        IHouse house = ALL_HOUSES.FirstOrDefault(x => x.Name == Sty.NAME);
        GameObject prefab = AddHouse(house, 0);
        BoughtHouses.Add(house.HouseIndex, prefab);
    }

    GameObject AddHouse(IHouse house, int houseIndexPosition)
    {
        if (m_housingParent == null)
            Debug.LogError("Housing Parent is null!");

        GameObject prefab = m_housePrefabs.FirstOrDefault(x => x.GetComponent<HouseBase>().Name == house.Name);
        if (prefab == null)
            Debug.LogError($"Can't find prefab for House '{house.Name}'");

        GameObject housePrefab = Instantiate(prefab);
        housePrefab.transform.SetParent(m_housingParent);

        var prevHouse = BoughtHouses.FirstOrDefault(x => x.Value.GetComponent<HouseBase>().HouseIndex == (houseIndexPosition - 1)).Value;
        Vector3 newPos = prevHouse != null ? GetNewPosition(housePrefab, prevHouse) : Vector3.zero;
        housePrefab.transform.localPosition = newPos;

        HouseBase houseController = housePrefab.GetComponent<HouseBase>();
        houseController.SetInfo(house);
        return housePrefab;
    }

    /// <summary>
    /// Upgrades the passed house to the target house
    /// </summary>
    /// <param name="house">The old house that will be upgrades</param>
    /// <param name="targetHouse">The house to upgrade the old one to</param>
    public void UpgradeHouse(IHouse house, IHouse targetHouse)
    {
        if (m_moneyManager.Money < house.BaseCost)
            return;

        if (BoughtHouses.ContainsKey(house.HouseIndex))
        {
            List<IHouse> houses = BoughtHouses.Values.Select(x => x.GetComponent<HouseBase>().HouseInfo).ToList();
            houses.Remove(house);
            houses.Add(targetHouse);

            targetHouse.CurrentCapacity = house.CurrentCapacity;
            targetHouse.HouseIndex = house.HouseIndex;

            SetBoughtHouses(houses);
        }
    }

    public void IncreaseCapacity(double modifyValue)
    {
        throw new NotImplementedException();
    }

    public void AddHouse(IHouse upgradeToHouse)
    {
        List<IHouse> houses = BoughtHouses.Values.Select(x => x.GetComponent<HouseBase>().HouseInfo).ToList();
        houses.Add(upgradeToHouse);
        UpdateHouses(houses);
    }

    /// <summary>
    /// From save file. Load and set previous bought houses
    /// </summary>
    /// <param name="boughtHouses"></param>
    public void SetBoughtHouses(List<IHouse> boughtHouses)
    {
        if (boughtHouses == null)
            return;

        UpdateHouses(boughtHouses);
    }

    void UpdateHouses(List<IHouse> newHouses)
    {
        foreach(int houseIndex in BoughtHouses.Keys)
        {
            Destroy(BoughtHouses[houseIndex]);
        }
        BoughtHouses.Clear();

        foreach (IHouse house in newHouses)
        {
            GameObject newHousePrefab = AddHouse(house, house.HouseIndex);

            HouseBase houseBase = newHousePrefab.GetComponent<HouseBase>();
            BoughtHouses.Add(houseBase.HouseIndex, newHousePrefab);
        }
    }

    Vector3 GetNewPosition(GameObject instHouse, GameObject previousInstHouse)
    {
        float newHouseWidth = instHouse.GetComponentInChildren<BoxCollider>().size.x;
        float prevHouseWidth = previousInstHouse.GetComponentInChildren<BoxCollider>().size.x;

        Vector3 prevHousePos = previousInstHouse.transform.localPosition;
        //Prev house position + (half of prev house width) + padding + (half of new house width)
        Vector3 newHousePos = new Vector3(prevHousePos.x + (prevHouseWidth / 2) + m_paddingWidth + (newHouseWidth / 2), prevHousePos.y, prevHousePos.z);

        return newHousePos;
    }
}
