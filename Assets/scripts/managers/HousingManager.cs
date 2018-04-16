using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HousingManager : MonoBehaviour
{
    public List<IHouse> Houses { get; set; }

    [SerializeField]
    GameObject[] m_housePrefabs;

    [SerializeField]
    Transform m_housingParent;

    const int MAX_HOUSES = 4;

    public HousingManager()
    {
        Houses = new List<IHouse>();
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
        if (Houses.Count >= MAX_HOUSES)
            return;

        if(Houses != null && Houses.Count > 0)
            Houses.Clear();

        AddHouse(0);
    }

    void AddHouse(int houseIndex)
    {
        if (m_housingParent == null)
            Debug.LogError("Housing Parent is null!");

        GameObject lowestHouse = Instantiate(m_housePrefabs.FirstOrDefault());
        lowestHouse.transform.SetParent(m_housingParent);
        lowestHouse.transform.localPosition = new Vector3(0f, 0f, 0f);

        Houses.Add(lowestHouse.GetComponent<IHouse>());
    }
}
