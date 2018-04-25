using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Timers;

public class FabricatorManager : MonoBehaviour
{
    float m_charge;
    public float Charge
    {
        get { return m_charge; }
        private set { m_charge = value; }
    }

    float m_chargeCapacity;
    public float ChargeCapacity
    {
        get { return m_chargeCapacity; }
        private set { m_chargeCapacity = value; }
    }

    MoneyManager m_moneyManager = null;
    HousingManager m_housingManager = null;

    bool m_isRecharging = false;
    /// <summary>
    /// The amount to increment every tick when recharging the fabricator charge
    /// </summary>
    float m_rechargeTickAmount = 0.001f;

    float m_clickDecreaseAmount = 1f;

    const float LOWEST_CHARGE_AMOUNT = 0f;

    private void Start()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_housingManager = FindObjectOfType<HousingManager>();

        Charge = ChargeCapacity;
    }

    private void Update()
    {
        if (m_isRecharging)
        {
            if (Charge >= ChargeCapacity)
                m_isRecharging = false;
            else
                Charge += m_rechargeTickAmount;
        }
    }

    public void CreatePig()
    {
        if (Charge <= LOWEST_CHARGE_AMOUNT)
            return;
        
        DecreaseCharge();

        //Find the house for the pig to go to and increment
        HouseBase lowestHouse = m_housingManager.BoughtHouses.Aggregate(
            (x, y) => x.Value.GetComponent<HouseBase>().CurrentCapacity < y.Value.GetComponent<HouseBase>().CurrentCapacity ? x : y
            ).Value.GetComponent<HouseBase>();

        if (lowestHouse != null)
        {
            lowestHouse.AddPigs(1);
        }
        else
        {
            Debug.Log("Unable to find lowest house to add pig");
        }
    }

    public void IncrementMaxCharge(float amount)
    {
        if(amount > 0)
            ChargeCapacity += amount;
    }

    public void DecreaseCharge()
    {
        if (Charge > 0f)
            Charge -= m_clickDecreaseAmount;

        m_isRecharging = true;
    }

    public void SetChargeAndCapacity(float charge, float chargeCapacity)
    {
        Charge = charge;
        ChargeCapacity = chargeCapacity;
    }
}
