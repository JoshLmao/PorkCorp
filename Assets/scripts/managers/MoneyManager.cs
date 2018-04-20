using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    float m_money;
    public int Money
    {
        get { return (int)Math.Round(m_money, 0); }
        private set { m_money = value; }
    }

    double m_sellValue = 0.0;
    public double SellValue
    {
        get { return m_sellValue; }
        private set { m_sellValue = value; }
    }

    public MoneyManager()
    {
        Money = 0;
        SellValue = 0.10;
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
        m_money += amount;
    }

    public void AddAmount(double amount)
    {
        m_money += (float)amount;
    }

    public void AddAmount(int amount)
    {
        m_money += amount;
    }

    public void RemoveAmount(double amount)
    {
        m_money -= (float)amount;
    }

    public void SetSellValue(double value)
    {
        SellValue = value;
    }
}
