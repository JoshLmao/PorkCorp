using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HousingManager : MonoBehaviour
{
    public Dictionary<IHouse, GameObject> BoughtHouses { get; private set; }

    [SerializeField]
    GameObject[] m_housePrefabs;

    [SerializeField]
    Transform m_housingParent;

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

        IHouse house = new Sty();
        GameObject prefab = AddHouse(house, 0);
        BoughtHouses.Add(house, prefab);
    }

    GameObject AddHouse(IHouse house, int houseIndexPosition)
    {
        if (m_housingParent == null)
            Debug.LogError("Housing Parent is null!");

        GameObject housePrefab = Instantiate(m_housePrefabs.FirstOrDefault(x => x.GetComponent<HouseBase>().Name == house.Name));
        housePrefab.transform.SetParent(m_housingParent);
        housePrefab.transform.localPosition = new Vector3(0f, 0f, 0f);
        m_createdHouses.Add(housePrefab);

        HouseBase houseController = housePrefab.GetComponent<HouseBase>();
        houseController.SetInfo(house);
        house.SetPrefabReference(houseController);
        return housePrefab;
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
}
