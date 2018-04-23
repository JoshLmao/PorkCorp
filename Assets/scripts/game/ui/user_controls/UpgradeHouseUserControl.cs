using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHouseUserControl : MonoBehaviour
{
    private string m_name;
    public string Name
    {
        get { return m_name; }
        set
        {
            m_name = value;
            if (m_houseNameText != null)
                m_houseNameText.text = value;
        }
    }

    private int m_currentCapacity;
    public int CurrentCapacity
    {
        get { return m_currentCapacity; }
        set
        {
            m_currentCapacity = value;
            UpdateCapacity();
        }
    }

    private int m_totalCapacity;
    public int TotalCapacity
    {
        get { return m_totalCapacity; }
        set
        {
            m_totalCapacity = value;
            UpdateCapacity();
        }
    }

    private Sprite m_icon;
    public Sprite Icon
    {
        get { return m_icon; }
        set
        {
            m_icon = value;
            if(m_houseIcon != null)
                m_houseIcon.sprite = value;
        }
    }

    IHouse m_dataContext;
    public IHouse DataContext
    {
        get { return m_dataContext; }
        set
        {
            m_dataContext = value;
            UpdateValues();
        }
    }
    public int HouseIndex { get; set; } = -1;

    public event Action<IHouse> OnUpgradeHouseClicked;
    public event Action<int> OnBuildHouseClicked;

    Text m_houseNameText;
    Text m_capacityText;
    Image m_houseIcon;
    Button m_upgradeBtn;
    Button m_buildBtn;

    private void Start()
    {
        m_houseNameText = transform.Find("Name").GetComponent<Text>();
        m_capacityText = transform.Find("Capacity").GetComponent<Text>();
        m_houseIcon = transform.Find("Icon").GetComponent<Image>();

        m_upgradeBtn = transform.Find("UpgradeBtn").GetComponent<Button>();
        m_upgradeBtn.onClick.AddListener(OnUpgradeBtnClicked);

        m_buildBtn = transform.Find("BuildBtn").GetComponent<Button>();
        m_buildBtn.onClick.AddListener(OnBuildBtnClicked);

        UpdateValues();
    }

    private void OnBuildBtnClicked()
    {
        OnBuildHouseClicked?.Invoke(HouseIndex);
    }

    private void OnUpgradeBtnClicked()
    {
        OnUpgradeHouseClicked?.Invoke(DataContext);
    }

    private void UpdateValues()
    {
        UpdateCapacity();
        Name = Name;
        Icon = Icon;

        //If one null, all should be null
        if (m_houseNameText == null)
            return;

        bool hasHouseBuilt = DataContext != null;
        m_houseNameText.gameObject.SetActive(hasHouseBuilt);
        m_capacityText.gameObject.SetActive(hasHouseBuilt);
        m_houseIcon.gameObject.SetActive(hasHouseBuilt);
        m_upgradeBtn.gameObject.SetActive(hasHouseBuilt);
        m_buildBtn.gameObject.SetActive(!hasHouseBuilt);
    }

    void UpdateCapacity()
    {
        if (m_capacityText != null)
            m_capacityText.text = $"{CurrentCapacity}/{TotalCapacity}";
    }
}
