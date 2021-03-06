using System;
using System.Linq;
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

    int m_researchUniqueMultiplier;
    public int ResearchUniqueMultiplier
    {
        get { return m_researchUniqueMultiplier; }
        set { m_researchUniqueMultiplier = value; }
    }

    HousingManager m_housingManager;
    DistributionManager m_distributionManager;

    public MoneyManager()
    {
        Money = 0;
        SellValue = 0.10;
        ResearchMultiplier = 1f;
    }

    private void Awake()
    {
        m_housingManager = FindObjectOfType<HousingManager>();
        m_distributionManager = FindObjectOfType<DistributionManager>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        UpdateMoney();
    }

    void UpdateMoney()
    {
        double totalVehicleSellRate = m_distributionManager.BoughtVehicles.Sum(x => x.SellRate);
        int totalCurrentPigs = m_housingManager.GetCurrentPigsAmount();

        double totalRawAmount = SellValue * totalCurrentPigs;
        double amountPerTick = totalRawAmount * Time.fixedDeltaTime;
        double amountToAdd = totalRawAmount * amountPerTick;
        AddAmount(amountToAdd);
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

    public void AddUniqueMultiplier(double modifyValue)
    {
        ResearchUniqueMultiplier += (int)modifyValue;
    }

    float GetMultipliedValue(double value)
    {
        if (ResearchMultiplier > 1f)
        {
            double baseMultiply = (value * ResearchMultiplier);
            if (ResearchUniqueMultiplier > 1f)
                return (float)(baseMultiply * ResearchUniqueMultiplier);
            else
                return (float)baseMultiply;
        }
        else
        {
            return (float)value;
        }
    }
}
