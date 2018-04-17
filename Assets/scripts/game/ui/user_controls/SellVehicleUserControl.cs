using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellVehicleUserControl : MonoBehaviour
{
    private string m_vehicleName = "None";
    public string VehicleName
    {
        get { return m_vehicleName; }
        set
        {
            m_vehicleName = value;
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
            m_sellRateText.text = string.Format("{0}/MIN", m_sellPerMinute);
        }
    }

    private double m_cost = 0;
    public double Cost
    {
        get { return m_cost; }
        set
        {
            m_cost = value;
            m_buyText.text = m_cost.ToString();
        }
    }

    private Sprite m_iconSprite = null;
    public Sprite IconSprite
    {
        get { return m_iconSprite; }
        set
        {
            m_iconSprite = value;
            m_iconImage.sprite = m_iconSprite;
        }
    }

    public event Action OnBuyButtonClick;

    Text m_vehicleNameText;
    Image m_iconImage;
    Text m_sellRateText;
    Text m_buyText;
    Button m_buyButton;

    private void Start()
    {
        m_vehicleNameText = transform.Find("Name").GetComponent<Text>();
        m_iconImage = transform.Find("Icon").GetComponent<Image>();
        m_sellRateText = transform.Find("SellRate").GetComponent<Text>();
        m_buyText = transform.Find("").GetComponent<Text>();

        m_buyButton = transform.Find("BuyBtn").GetComponent<Button>();
        m_buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        if (OnBuyButtonClick != null)
            OnBuyButtonClick.Invoke();
    }
}
