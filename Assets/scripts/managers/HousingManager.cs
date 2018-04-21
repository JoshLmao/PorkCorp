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
    };

    public Dictionary<IHouse, GameObject> BoughtHouses { get; private set; }

    [SerializeField]
    GameObject[] m_housePrefabs;

    [SerializeField]
    Transform m_housingParent;

    [SerializeField]
    float m_paddingWidth = 0f;

    List<GameObject> m_createdHouses = new List<GameObject>();

    const int MAX_HOUSES = 4;

    public HousingManager()
    {
        BoughtHouses = new Dictionary<IHouse, GameObject>(); 
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
        BoughtHouses.Add(house, prefab);
    }

    GameObject AddHouse(IHouse house, int houseIndexPosition)
    {
        if (m_housingParent == null)
            Debug.LogError("Housing Parent is null!");

        GameObject housePrefab = Instantiate(m_housePrefabs.FirstOrDefault(x => x.GetComponent<HouseBase>().Name == house.Name));
        housePrefab.transform.SetParent(m_housingParent);

        var prevHouse = BoughtHouses.FirstOrDefault(x => x.Key.HouseIndex == (houseIndexPosition - 1)).Value;
        Vector3 newPos = prevHouse != null ? GetNewPosition(housePrefab, prevHouse) : Vector3.zero;
        housePrefab.transform.localPosition = newPos;
        m_createdHouses.Add(housePrefab);

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
        
    }

    /// <summary>
    /// From save file. Load and set previous bought houses
    /// </summary>
    /// <param name="boughtHouses"></param>
    public void SetBoughtHouses(List<IHouse> boughtHouses)
    {
        if (boughtHouses == null)
            return;

        //List<IHouse> oldHouses = BoughtHouses.ToList();
        //BoughtHouses = boughtHouses;
        UpdateHouses(boughtHouses);
    }

    void UpdateHouses(List<IHouse> newHouses)
    {
        DestroyChildHouses();
        m_createdHouses.Clear();

        int houseIndexPos = 0;
        foreach (IHouse house in newHouses)
        {
            GameObject newHousePrefab = AddHouse(house, houseIndexPos);
            BoughtHouses.Add(newHousePrefab.GetComponent<HouseBase>().HouseInfo, newHousePrefab);
        }
    }

    void DestroyChildHouses()
    {
        foreach(Transform t in m_housingParent)
        {
            Destroy(t.gameObject);
        }
        m_createdHouses.Clear();
    }

    Vector3 GetNewPosition(GameObject instHouse, GameObject previousInstHouse)
    {
        float newHouseWidth = instHouse.GetComponentInChildren<BoxCollider>().size.x;
        float prevHouseWidth = previousInstHouse.GetComponentInChildren<BoxCollider>().size.x;

        Vector3 prevHousePos = previousInstHouse.transform.localPosition;
        //Prev house position + (half of prev house width) + padding + (half of new house width)
        Vector3 newHousePos = new Vector3(prevHousePos.x + (prevHouseWidth / 2) + m_paddingWidth + (newHouseWidth / 2), prevHousePos.y, prevHousePos.z);
        Debug.Log(newHousePos);
        return newHousePos;
    }
}
