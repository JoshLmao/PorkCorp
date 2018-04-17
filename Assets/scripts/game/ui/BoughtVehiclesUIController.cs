using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoughtVehiclesUIController : MonoBehaviour, ISellVehiclesUI
{
    [SerializeField]
    Transform m_vehiclesListParent;

    [SerializeField]
    GameObject m_boughtVehicleUserControlPrefab;

    [SerializeField]
    float m_uiStartYPosition = 210f;

    [SerializeField]
    float m_uiSpacingValue = 100f;

    DistributionManager m_distributionManager;

    /// <summary>
    /// List of all instantiated UI buttons
    /// </summary>
    List<BoughtVehiclesUserControl> m_boughtVehiclesUCs = new List<BoughtVehiclesUserControl>();
    /// <summary>
    /// Current list of bought vehicles (dtos)
    /// </summary>
    List<ISellVehicle> m_currentBoughtVehicles = null;

    private void Awake()
    {
        m_distributionManager = FindObjectOfType<DistributionManager>();

        OnHideVehiclesUI();

        if (m_boughtVehicleUserControlPrefab == null)
            Debug.LogError("Bought Prefab null");
    }

    private void Start()
    {
        UpdateVehicleList();
    }

    private void Update()
    {
        
    }

    public void OnShowVehiclesUI()
    {
        this.gameObject.SetActive(true);
    }

    public void OnHideVehiclesUI()
    {
        this.gameObject.SetActive(false);
    }

    void UpdateVehicleList()
    {
        List<GameObject> children = new List<GameObject>();
        foreach(Transform existingChildren in m_vehiclesListParent)
            Destroy(existingChildren.gameObject);

        m_boughtVehiclesUCs.Clear();
        float currentY = m_uiStartYPosition;
        for(int i = 0; i < m_distributionManager.VehicleLimit; i++)
        {
            GameObject ui = Instantiate(m_boughtVehicleUserControlPrefab, m_vehiclesListParent);

            ui.GetComponent<RectTransform>().localPosition = new Vector3(ui.transform.localPosition.x, currentY, ui.transform.localPosition.z);
            currentY -= m_uiSpacingValue; //gap between UI

            //Find dto that matches current index
            ISellVehicle foundVehicle = null;
            if (m_currentBoughtVehicles != null && m_currentBoughtVehicles.Count > 0)
                foundVehicle = m_currentBoughtVehicles.FirstOrDefault(x => x.VehicleIndex == i);

            if (foundVehicle != null)
                ui.name = foundVehicle.Name;

            BoughtVehiclesUserControl uc = ui.GetComponent<BoughtVehiclesUserControl>();
            uc.DataContext = foundVehicle;

            uc.IsBought = foundVehicle != null;
            uc.VehicleName = foundVehicle != null ? foundVehicle.Name : "?";
            uc.IconSprite = null;
            uc.SellRatePerMinute = foundVehicle != null ? foundVehicle.SellRate.ToString() : "0.0";

            uc.OnHireButtonClicked += OnHireBtnClicked;
            uc.OnUpgradeBtnClicked += OnUpgradeBtnClicked;

            m_boughtVehiclesUCs.Add(uc);
        }
    }

    private void OnUpgradeBtnClicked(ISellVehicle upgradeVehicle)
    {

    }

    public void SetBoughtSellVehicles(List<ISellVehicle> boughtVehicles)
    {
        m_currentBoughtVehicles = boughtVehicles;
    }

    private void OnHireBtnClicked(ISellVehicle vehicle)
    {
        if(vehicle != null)
        {
            m_distributionManager.HireVehicle(vehicle);
        }
    }
}
