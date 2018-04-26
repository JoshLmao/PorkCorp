using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private float m_money;
    public float Money
    {
        get { return (int)Math.Round(m_money, 0); }
        private set { m_money = value; }
    }

    private double m_sellValue;
    public double SellValue
    {
        get { return m_sellValue; }
        private set { m_sellValue = value; }
    }

    private double m_researchMultiplier;
    public double ResearchMultiplier
    {
        get { return m_researchMultiplier; }
        set { m_researchMultiplier = value; }
    }

    public MoneyManager()
    {
        Money = 0;
        SellValue = 0.10;
        ResearchMultiplier = 1f;
    }

    void Awake()
    {
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void AddAmount(float amount)
    {
        m_money += GetMultipliedValue(amount);
    }

    public void AddAmount(double amount)
    {
        m_money += GetMultipliedValue(amount);
    }

    public void AddAmount(int amount)
    {
        m_money += GetMultipliedValue(amount);
    }

    public void RemoveAmount(double amount)
    {
        m_money -= (float)amount;
    }

    public void SetSellValue(double value)
    {
        SellValue = value;
    }

    public void IncreaseResearchValue(double amount)
    {
        ResearchMultiplier += amount;
    }

    float GetMultipliedValue(double value)
    {
        if (ResearchMultiplier > 1f)
            return (float)(value * ResearchMultiplier);
        else
            return (float)value;
    }
}
