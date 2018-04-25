using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public event System.Action<SaveFileDto, List<IResearch>, List<ISellVehicle>, List<IHouse>> OnDataLoaded;

    DistributionManager m_distributionManager;
    MoneyManager m_moneyManager;
    HousingManager m_housingManager;
    FabricatorManager m_fabricatorManager;
    ResearchManager m_researchManager;

    ApplicationController m_appController;

    SaveFileDto m_currentData = null;
    List<IHouse> m_houses = null;
    List<ISellVehicle> m_vehicles = null;
    List<IResearch> m_research = null;

    string m_mainFilePath = null;
    string m_vehiclesSavePath;
    string m_housesSavePath;
    string m_researchSavePath;

    Coroutine m_saveCoroutine = null;

    const string FILE_NAME = "PorkCorpSave.json";
    const string VEHICLES_FILE_NAME = "Vehicles.json";
    const string HOUSES_FILE_NAME = "Houses.json";
    const string RESEARCH_FILE_NAME = "Research.json";
        
    #region MonoBehavious
    private void Awake()
    {
        m_distributionManager = FindObjectOfType<DistributionManager>();
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
        m_researchManager = FindObjectOfType<ResearchManager>();

        m_mainFilePath = Path.Combine(Application.persistentDataPath, FILE_NAME);
        m_vehiclesSavePath = Path.Combine(Application.persistentDataPath, VEHICLES_FILE_NAME);
        m_housesSavePath = Path.Combine(Application.persistentDataPath, HOUSES_FILE_NAME);
        m_researchSavePath = Path.Combine(Application.persistentDataPath, RESEARCH_FILE_NAME);
    }

    private void Start()
    {
        LoadData();
    }

#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
    private void OnApplicationFocus(bool isFocused)
    {
        if (!isFocused)
        {
            OnSaveFile();
        }
    }
#endif

#if !UNITY_IOS && !UNITY_ANDROID
    private void OnApplicationQuit()
    {

    }
#endif
    #endregion

    IEnumerator SaveData()
    {
        UpdateData();

        yield return SaveFile(m_mainFilePath, m_currentData);
        yield return SaveFile(m_vehiclesSavePath, m_vehicles);
        yield return SaveFile(m_researchSavePath, m_research);
        yield return SaveFile(m_housesSavePath, m_houses);
        
        //Debug.Log("Saving complete");
        m_saveCoroutine = null;
    }

    IEnumerator SaveFile(string file, object obj)
    {
        if (!File.Exists(file))
            File.Create(file).Close();

        string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings());
        File.WriteAllText(file, json);
        yield return true;
    }

    void LoadData()
    {
        if (File.Exists(m_mainFilePath))
        {
            SaveFileDto saveFile = null;
            try
            {
                string json = File.ReadAllText(m_mainFilePath);
                saveFile = JsonConvert.DeserializeObject<SaveFileDto>(json); 
            }
            catch(Exception e)
            {
                Debug.LogError(string.Format("Exception occured when attempting to load Save File. {0}StackTrace - {1}", Environment.NewLine, e.ToString()));
            }
            finally
            {
                m_currentData = saveFile;
            }

            if (saveFile == null)
            {
                Debug.LogError("Unable to load save filefile");
                return;
            }

            m_vehicles = LoadCustom<List<ISellVehicle>>(m_vehiclesSavePath, new VehicleConverter());
            m_research = LoadCustom<List<IResearch>>(m_researchSavePath, new ResearchJsonConverter(m_researchManager));
            m_houses = LoadCustom<List<IHouse>>(m_housesSavePath, new HouseJsonConverter());
        }

        if (OnDataLoaded != null)
            OnDataLoaded.Invoke(m_currentData, m_research, m_vehicles, m_houses);
    }

    /// <summary>
    /// Updated the data inside the save file with the latest properties
    /// </summary>
    void UpdateData()
    {
        if (m_currentData == null)
            m_currentData = new SaveFileDto();

        m_houses = m_housingManager.BoughtHouses.Values.Select(x => x.GetComponent<HouseBase>().HouseInfo).ToList();
        m_research = m_researchManager.AllResearch;
        m_vehicles = m_distributionManager.BoughtVehicles;

        m_currentData.Money = m_moneyManager.Money;
        m_currentData.SellValue = m_moneyManager.SellValue;
        m_currentData.FabricatorCapacity = m_fabricatorManager.Charge;
        m_currentData.FabricatorMaxCapacity = m_fabricatorManager.ChargeCapacity;
    }

    /// <summary>
    /// Loads a file that contains json with interfaces and converts them using the customConverter to instances
    /// </summary>
    /// <typeparam name="T">The type to convert to (usually the interface)</typeparam>
    /// <param name="path">The file path to the json file</param>
    /// <param name="customConverter">The custom json converter that handles converting interfaces into instances</param>
    /// <returns>The populated type</returns>
    T LoadCustom<T>(string path, JsonConverter customConverter)
    {
        if (!File.Exists(path))
            return default(T);
        
        T customConvertedObj = default(T);
        try
        {
            string json = File.ReadAllText(path);
            customConvertedObj = JsonConvert.DeserializeObject<T>(json, customConverter);
        }
        catch (Exception e)
        {
            Debug.Log($"Unable to load file '{path}' - {Environment.NewLine}{e.ToString()}");
        }

        return customConvertedObj;
    }

    public void OnSaveFile()
    {
        if (m_saveCoroutine == null)
        {
            Debug.Log("Saving game...");
            m_saveCoroutine = StartCoroutine(SaveData());
        }
    }
}
