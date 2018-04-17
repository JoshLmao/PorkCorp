using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    HousingManager m_housingManager = null;
    MoneyManager m_moneyManager = null;
    DistributionManager m_distributionManager = null;

    object m_saveFile = null;

    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_distributionManager = FindObjectOfType<DistributionManager>();
    }

    private void Start ()
    {
        if (m_saveFile == null)
        {
            //Start new game
            m_housingManager.AddNewStartHouses();
            //m_moneyManager.Money = 0;
            m_distributionManager.SetStartVehicles();
        }
	}

    private void Update ()
    {
		
	}
}
