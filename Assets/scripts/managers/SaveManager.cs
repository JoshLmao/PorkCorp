using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public event System.Action<SaveFileDto> OnDataLoaded;

    DistributionManager m_distributionManager;
    MoneyManager m_moneyManager;
    HousingManager m_housingManager;
    FabricatorManager m_fabricatorManager;
    ResearchManager m_researchManager;

    ApplicationController m_appController;

    SaveFileDto m_currentData = null;
    string m_filePath = Path.Combine(Application.persistentDataPath, "FILE_NAME");

    const string FILE_NAME = "PorkCorpSave.json";

    private void Awake()
    {
        m_distributionManager = FindObjectOfType<DistributionManager>();
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
    }

    private void Start()
    {
        LoadData();
    }

    void SaveData()
    {
        UpdateData();

        string json = JsonConvert.SerializeObject(m_currentData);
        if (!File.Exists(m_filePath))
        {
            File.Create(m_filePath).Close();
        }

        File.WriteAllText(m_filePath, json);
    }

    void LoadData()
    {
        if (File.Exists(m_filePath))
        {
            SaveFileDto saveFile = JsonConvert.DeserializeObject<SaveFileDto>(m_filePath);
            if (saveFile == null)
            {
                Debug.LogError("Unable to load file");
            }

            m_currentData = saveFile;
        }

        if (OnDataLoaded != null)
            OnDataLoaded.Invoke(m_currentData);
    }

    void UpdateData()
    {
        if (m_currentData == null)
            m_currentData = new SaveFileDto();

        m_currentData.BoughtHouses = m_housingManager.BoughtHouses;
        m_currentData.BoughtResearches = m_researchManager.BoughtResearch;
        m_currentData.BoughtVehicles = m_distributionManager.BoughtVehicles;

        m_currentData.Money = m_moneyManager.Money;
    }
}
