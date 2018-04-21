using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FabricatorManager : MonoBehaviour
{
    MoneyManager m_moneyManager = null;
    HousingManager m_housingManager = null;
    
    private void Start()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
    }

    public void CreatePig()
    {
        //Find the house for the pig to go to and increment
        HouseBase lowestHouse = m_housingManager.BoughtHouses.Aggregate((x, y) => x.Key.CurrentCapacity < y.Key.CurrentCapacity ? x : y).Value.GetComponent<HouseBase>();
        if(lowestHouse != null)
        {
            lowestHouse.AddPigs(1);
        }
    }
}
