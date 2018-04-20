using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HousingManager : MonoBehaviour
{
    public List<IHouse> BoughtHouses { get; set; }

    [SerializeField]
    GameObject[] m_housePrefabs;

    [SerializeField]
    Transform m_housingParent;

    List<GameObject> m_createdHouses = new List<GameObject>();

    const int MAX_HOUSES = 4;

    public HousingManager()
    {
        BoughtHouses = new List<IHouse>();
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

        AddHouse(m_housePrefabs.FirstOrDefault().GetComponent<IHouse>(), 0);
    }

    IHouse AddHouse(IHouse house, int houseIndexPosition)
    {
        if (m_housingParent == null)
            Debug.LogError("Housing Parent is null!");

        GameObject housePrefab = Instantiate(m_housePrefabs.FirstOrDefault(x => x.GetComponent<IHouse>().TotalCapacity == house.TotalCapacity));
        housePrefab.transform.SetParent(m_housingParent);
        housePrefab.transform.localPosition = new Vector3(0f, 0f, 0f);
        m_createdHouses.Add(housePrefab);

        IHouse houseDto = housePrefab.GetComponent<IHouse>();
        houseDto.HouseIndex = houseIndexPosition;
        return houseDto;
    }

    public void SetBoughtHouses(List<IHouse> boughtHouses)
    {
        if (boughtHouses == null)
            return;

        List<IHouse> oldHouses = BoughtHouses.ToList();
        BoughtHouses = boughtHouses;
        UpdateHouses(oldHouses);
    }

    void UpdateHouses(List<IHouse> previousHouses)
    {
        DestroyChildHouses();
        m_createdHouses.Clear();

        int houseIndexPos = 0;
        foreach (IHouse house in BoughtHouses)
        {
            IHouse oldHouse = previousHouses.FirstOrDefault(x => x.HouseIndex == house.HouseIndex);
            IHouse newHouse = AddHouse(house, houseIndexPos);
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
