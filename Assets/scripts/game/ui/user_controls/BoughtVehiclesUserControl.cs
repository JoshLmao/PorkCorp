using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoughtVehiclesUserControl : MonoBehaviour
{
    private string m_vehicleName = "None";
    public string VehicleName
    {
        get { return m_vehicleName; }
        set
        {
            m_vehicleName = value;
            if(m_vehicleNameText != null)
                m_vehicleNameText.text = m_vehicleName;
        }
    }

    private string m_sellPerMinute = "0";
    public string SellRatePerMinute
    {
        get { return m_sellPerMinute; }
        set
        {
            m_sellPerMinute = value;
            if(m_sellRateText != null)
                m_sellRateText.text = string.Format("{0}/MIN", m_sellPerMinute);
        }
    }

    private Sprite m_iconSprite = null;
    public Sprite IconSprite
    {
        get { return m_iconSprite; }
        set
        {
            m_iconSprite = value;
            if(m_iconImage != null)
                m_iconImage.sprite = m_iconSprite;
        }
    }

    bool m_isBought = false;
    public bool IsBought
    {
        get { return m_isBought; }
        set
        {
            m_isBought = value;
            if(m_hireButton != null)
                m_hireButton.gameObject.SetActive(!value);

        }
    }

    public event Action<ISellVehicle> OnHireButtonClicked;
    public event Action<ISellVehicle> OnUpgradeBtnClicked;

    public ISellVehicle DataContext { get; set; }

    Text m_vehicleNameText;
    Image m_iconImage;
    Text m_sellRateText;
    Image m_backgroundImage;

    Button m_hireButton;
    Button m_upgradeButton;

    Color m_enabledColor;

    private void Awake()
    {
    }

    private void Start()
    {
        m_vehicleNameText = transform.Find("Name").GetComponent<Text>();
        m_iconImage = transform.Find("Icon").GetComponent<Image>();
        m_sellRateText = transform.Find("SellRate").GetComponent<Text>();
        m_backgroundImage = transform.Find("Bg").GetComponent<Image>();
        m_enabledColor = m_backgroundImage.color;

        m_hireButton = transform.Find("Hire").GetComponent<Button>();
        m_hireButton.onClick.AddListener(HireBtnClicked);

        m_upgradeButton = transform.Find("UpgradeBtn").GetComponent<Button>();
        m_upgradeButton.onClick.AddListener(UpgradeBtnClicked);

        m_hireButton.gameObject.SetActive(!IsBought);

        m_vehicleNameText.gameObject.SetActive(IsBought);
        m_iconImage.gameObject.SetActive(IsBought);
        m_sellRateText.gameObject.SetActive(IsBought);
        m_upgradeButton.gameObject.SetActive(IsBought);

        m_backgroundImage.color = IsBought ? m_enabledColor : new Color()
        {
            r = m_enabledColor.r,
            g = m_enabledColor.g,
            b = m_enabledColor.b,
            a = 0.75f,
        };

        UpdateValues();
    }

    void UpdateValues()
    {
        IsBought = IsBought;
        VehicleName = VehicleName;
        SellRatePerMinute = SellRatePerMinute;
        IconSprite = IconSprite;
    }

    private void UpgradeBtnClicked()
    {
        if (OnUpgradeBtnClicked != null)
            OnUpgradeBtnClicked.Invoke(DataContext);
    }

    private void HireBtnClicked()
    {
        if (OnHireButtonClicked != null)
            OnHireButtonClicked.Invoke(DataContext);
    }
}
