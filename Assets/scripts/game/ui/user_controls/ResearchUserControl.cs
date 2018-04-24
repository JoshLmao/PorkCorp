using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchUserControl : MonoBehaviour
{
    private string m_name = "";
    public string Name
    {
        get { return m_name; }
        set
        {
            m_name = value;
            if(m_nameText != null)
                m_nameText.text = value;
        }
    }

    private string m_description = "";
    public string Description
    {
        get { return m_description; }
        set
        {
            m_description = value;
            if (m_descText != null)
                m_descText.text = value;
        }
    }

    private double m_cost = 0.0;
    public double Cost
    {
        get { return m_cost; }
        set
        {
            m_cost = value;
            if (m_costText != null)
                m_costText.text = m_cost.ToString();
        }
    }

    private Sprite m_icon;
    public Sprite Icon
    {
        get { return m_icon; }
        set
        {
            m_icon = value;
            if (m_iconImage != null)
                m_iconImage.sprite = value;
        }
    }

    int m_amountBought;
    public int AmountBought
    {
        get { return m_amountBought; }
        set
        {
            m_amountBought = value;

            if(m_capacitySlider != null)
            {
                m_capacitySlider.maxValue = MaxAmountAllowed;
                m_capacitySlider.value = value;

                //Set button status if bought all
                bool isResearchComplete = AmountBought >= MaxAmountAllowed;
                m_checkIcon.gameObject.SetActive(isResearchComplete);
                m_buyResearchBtn.gameObject.SetActive(!isResearchComplete);
            }
        }
    }

    public int MaxAmountAllowed { get; set; }

    public IResearch DataContext { get; set; }

    public event System.Action<IResearch> OnBuyResearch;

    Text m_costText;
    Text m_nameText;
    Text m_descText;
    Image m_iconImage;
    Image m_checkIcon;
    Button m_buyResearchBtn;
    Slider m_capacitySlider;

    private void Start()
    {
        m_buyResearchBtn = transform.Find("BuyBtn").GetComponent<Button>();
        m_buyResearchBtn.onClick.AddListener(OnBuyResearchClick);

        m_costText = m_buyResearchBtn.transform.Find("Cost").GetComponent<Text>();

        m_iconImage = transform.Find("Icon").GetComponent<Image>();
        m_nameText = transform.Find("Name").GetComponent<Text>();
        m_descText = transform.Find("Desc").GetComponent<Text>();
        m_capacitySlider = transform.Find("Capacity").GetComponent<Slider>();
        m_checkIcon = transform.Find("Check").GetComponent<Image>();

        UpdateValues();
    }

    private void OnBuyResearchClick()
    {
        if (OnBuyResearch != null)
            OnBuyResearch.Invoke(DataContext);
    }

    private void UpdateValues()
    {
        Description = Description;
        Name = Name;
        Cost = Cost;
        Icon = Icon;
        AmountBought = AmountBought;
    }
}
