using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    HousingManager m_housingManager = null;
    MoneyManager m_moneyManager = null;

    object m_saveFile = null;

    private void Awake()
    {

    }

    private void Start ()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();

        if (m_saveFile == null)
        {
            //Start new game
            m_housingManager.AddNewStartHouses();
            m_moneyManager.Money = 0.0;
        }
	}

    private void Update ()
    {
		
	}
}
