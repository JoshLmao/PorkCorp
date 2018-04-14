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
        int lowestCapacity = m_housingManager.Houses.Min(x => x.CurrentCapacity);
        IHouse lowestHouse = m_housingManager.Houses.FirstOrDefault(x => x.CurrentCapacity == lowestCapacity);
        if(lowestHouse != null)
        {
            lowestHouse.AddPig();
        }
    }
}
