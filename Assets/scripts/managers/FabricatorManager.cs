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

    [SerializeField]
    GameObject[] m_fabricatorPrefabs;

    [SerializeField]
    Transform m_fabricatorParent;

    [SerializeField]
    GameObject[] m_pigPrefabs;

    [SerializeField]
    Transform m_pigParent;

    FabricatorController m_currentFabricator = null;

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
                Charge += m_rechargeTickAmount * 1000;
        }
    }

    public void CreatePig()
    {
        if (Charge <= LOWEST_CHARGE_AMOUNT)
            return;
        
        DecreaseCharge();

        //Find the house for the pig to go to and increment
        HouseController lowestHouse = GetLowestHouse();
        if(lowestHouse != null)
        {
            SpawnPig(lowestHouse.GetWalkToPosition());
            lowestHouse.AddTransit(1);
        }
    }

    public void IncrementMaxCharge(double amount)
    {
        if(amount <= 0)
            return;

        ChargeCapacity += (float)amount;
    }

    public void IncreaseChargeRate(double percentageValue)
    {
        double amount = m_rechargeTickAmount / percentageValue;
        m_rechargeTickAmount += (float)amount;
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

        m_isRecharging = charge < ChargeCapacity;
    }

    void SpawnPig(Transform target)
    {
        if (target == null)
        {
            Debug.Log("Unable to spawn pig to target. Transform is null");
            return;
        }

        GameObject pig = Instantiate(m_pigPrefabs[0], m_pigParent);
        PigController pigController = pig.GetComponent<PigController>();
        pigController.SetTargetPosition(target);

        pigController.transform.position = m_currentFabricator.GetSpawnLocation().position;
    }

    public void SetMeatLevel(MeatLevel level)
    {
        GameObject fabPrefab = m_fabricatorPrefabs.FirstOrDefault(x => x.GetComponent<FabricatorController>().Level == level);
        if (fabPrefab != null)
        {
            GameObject instFabricator = Instantiate(fabPrefab, m_fabricatorParent);
            m_currentFabricator = instFabricator.GetComponent<FabricatorController>();
        }
        else
        {
            Debug.Log($"Unable to find Fabricator prefab for level {level}");
        }
    }

    /// <summary>
    /// Gets the lowest house that a pig should be sent to. Will return null if pig shouldn't be created
    /// </summary>
    /// <returns>The lowest house or null</returns>
    HouseController GetLowestHouse()
    {
        HouseController house = null;
        foreach(KeyValuePair<int, GameObject> kvp in m_housingManager.BoughtHouses)
        {
            HouseController currentHouse = kvp.Value.GetComponent<HouseController>();
            if (currentHouse.CurrentCapacity + currentHouse.TransitCount < currentHouse.TotalCapacity)
                house = currentHouse;
        }
         
        return house;

        /*m_housingManager.BoughtHouses.Aggregate(
            (x, y) => x.Value.GetComponent<HouseController>().CurrentCapacity < y.Value.GetComponent<HouseController>().CurrentCapacity ? x : y
        ).Value.GetComponent<HouseController>();*/
    }
}
