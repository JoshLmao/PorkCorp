using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyVehicleUserControl : MonoBehaviour
{
    private string m_vehicleName = "None";
    public string VehicleName
    {
        get { return m_vehicleName; }
        set
        {
            m_vehicleName = value;
            if (m_vehicleNameText != null)
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
            if (m_perMinuteText != null)
                m_perMinuteText.text = string.Format("{0}/MIN", m_sellPerMinute);
        }
    }

    private Sprite m_iconSprite = null;
    public Sprite IconSprite
    {
        get { return m_iconSprite; }
        set
        {
            m_iconSprite = value;
            if (m_iconImage != null)
                m_iconImage.sprite = m_iconSprite;
        }
    }

    public ISellVehicle DataContext { get; set; }

    public event Action<ISellVehicle> OnBuyVehicle; 

    Image m_iconImage;
    Text m_perMinuteText;
    Text m_vehicleNameText;

    Button m_buyButton;

    private void Start()
    {
        m_vehicleNameText = transform.Find("Name").GetComponent<Text>();
        m_iconImage = transform.Find("Icon").GetComponent<Image>();
        m_perMinuteText = transform.Find("PerMin").GetComponent<Text>();

        m_buyButton = transform.Find("BuyBtn").GetComponent<Button>();
        m_buyButton.onClick.AddListener(BuyBtnClicked);

        UpdateValues();
    }
    
    private void UpdateValues()
    {
        VehicleName = VehicleName;
        SellRatePerMinute = SellRatePerMinute;
        IconSprite = IconSprite;
    }

    private void BuyBtnClicked()
    {
        if (OnBuyVehicle != null)
            OnBuyVehicle.Invoke(DataContext);
    }
}
