using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHouseUserControl : MonoBehaviour
{
    string m_name;
    public string Name
    {
        get { return m_name; }
        set
        {
            m_name = value;
            if (m_nameText != null)
                m_nameText.text = value;
        }
    }

    int m_capacity;
    public int Capacity
    {
        get { return m_capacity; }
        set
        {
            m_capacity = value;
            if (m_capacityText != null)
                m_capacityText.text = value.ToString();
        }
    }

    double m_cost;
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

    public IHouse DataContext { get; set; }
    public event Action<IHouse> OnBuyHouse;

    Text m_nameText;
    Text m_capacityText;
    Button m_buyHouseBtn;
    Text m_costText;

    private void Start()
    {
        m_nameText = transform.Find("Name").GetComponent<Text>();
        m_capacityText = transform.Find("Capacity").GetComponent<Text>();

        m_buyHouseBtn = transform.Find("BuyBtn").GetComponent<Button>();
        m_buyHouseBtn.onClick.AddListener(OnBuyHouseClicked);

        m_costText = m_buyHouseBtn.transform.Find("Cost").GetComponent<Text>();

        UpdateValues();
    }

    private void UpdateValues()
    {
        Name = Name;
        Cost = Cost;
        Capacity = Capacity;
    }

    private void OnBuyHouseClicked()
    {
        OnBuyHouse?.Invoke(DataContext);
    }
}
