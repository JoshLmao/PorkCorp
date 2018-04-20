﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    HousingManager m_housingManager = null;
    MoneyManager m_moneyManager = null;
    DistributionManager m_distributionManager = null;

    SaveManager m_saveManager;

    #region MonoBehavious
    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_distributionManager = FindObjectOfType<DistributionManager>();

        m_saveManager = FindObjectOfType<SaveManager>();
        m_saveManager.OnDataLoaded += OnDataLoaded;
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }
    #endregion

    private void OnDataLoaded(SaveFileDto saveFile)
    {
        if (saveFile != null)
        {
            m_moneyManager.SetSellValue(saveFile.SellValue);
            m_housingManager.SetBoughtHouses(saveFile.BoughtHouses);
        }
        else
        {
            ///No save file found. Start new game
            
            m_housingManager.AddNewStartHouses();
            //m_moneyManager.Money = 0; 
            m_moneyManager.SetSellValue(SellValueConstants.SellValues.FirstOrDefault());
            m_distributionManager.SetStartVehicles();
        }
    }
}
