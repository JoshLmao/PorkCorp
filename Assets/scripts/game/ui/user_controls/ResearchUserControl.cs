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
                m_costText.text = value.ToString();
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

    public IResearch DataContext { get; set; }

    public event System.Action<IResearch> OnBuyResearch;

    Text m_costText;
    Text m_nameText;
    Text m_descText;
    Image m_iconImage;
    Button m_buyResearchBtn;

    private void Start()
    {
        m_buyResearchBtn = transform.Find("BuyBtn").GetComponent<Button>();
        m_costText = transform.Find("BuyBtn/Cost").GetComponent<Text>();
        m_iconImage = transform.Find("Icon").GetComponent<Image>();
        m_nameText = transform.Find("Name").GetComponent<Text>();
        m_descText = transform.Find("Desc").GetComponent<Text>();

        m_buyResearchBtn.onClick.AddListener(OnBuyResearchClick);

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
    }
}
