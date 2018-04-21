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

    public IHouse DataContext { get; set; }

    public event Action<IHouse> OnUpgradeHouseClicked;

    Text m_houseNameText;
    Text m_capacityText;
    Image m_houseIcon;
    Button m_upgradeBtn;

    private void Start()
    {
        m_houseNameText = transform.Find("Name").GetComponent<Text>();
        m_capacityText = transform.Find("Capacity").GetComponent<Text>();
        m_houseIcon = transform.Find("Icon").GetComponent<Image>();

        m_upgradeBtn = transform.Find("UpgradeBtn").GetComponent<Button>();
        m_upgradeBtn.onClick.AddListener(OnUpgradeBtnClicked);

        UpdateValues();
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
    }

    void UpdateCapacity()
    {
        if (m_capacityText != null)
            m_capacityText.text = $"{CurrentCapacity}/{TotalCapacity}";
    }
}
