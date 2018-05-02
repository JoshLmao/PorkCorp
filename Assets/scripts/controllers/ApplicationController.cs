using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    HousingManager m_housingManager = null;
    MoneyManager m_moneyManager = null;
    DistributionManager m_distributionManager = null;
    ResearchManager m_researchManager;
    FabricatorManager m_fabricatorManager;

    SaveManager m_saveManager;

    #region MonoBehavious
    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_distributionManager = FindObjectOfType<DistributionManager>();
        m_researchManager = FindObjectOfType<ResearchManager>();
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();

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

    private void OnDataLoaded(SaveFileDto saveFile, List<IResearch> researches, List<ISellVehicle> vehicles, List<IHouse> houses)
    {
        if (saveFile != null)
        {
            m_moneyManager.SetSellValue(saveFile.SellValue);
            m_moneyManager.AddAmount(saveFile.Money);

            m_housingManager.SetBoughtHouses(houses);
            m_distributionManager.SetVehicles(vehicles);
            m_researchManager.SetResearch(researches);

            m_fabricatorManager.SetMeatLevel(saveFile.Level);

            if (saveFile.FabricatorCapacity > 0f && saveFile.FabricatorMaxCapacity > 0f)
            {
                m_fabricatorManager.SetChargeAndCapacity(saveFile.FabricatorCapacity, saveFile.FabricatorMaxCapacity);
            }
            else
            {
                Debug.LogError("Unable to set Fabricator Charge & ChargeCapacity. Saved values are less than 0");
                m_fabricatorManager.SetChargeAndCapacity(10f, 10f);
            }
        }
        else
        {
            ///No save file found. Start new game
            //m_moneyManager.Money = 0; 

            m_moneyManager.SetSellValue(SellValueConstants.SellValues.FirstOrDefault());
            m_housingManager.AddNewStartHouses();
            m_distributionManager.SetVehicles(null);

            m_fabricatorManager.SetMeatLevel(MeatLevel.Standard);
            m_fabricatorManager.SetChargeAndCapacity(10f, 10f);
        }
    }
}
