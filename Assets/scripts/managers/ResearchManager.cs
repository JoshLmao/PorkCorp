using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    public List<IResearch> BoughtResearch { get; private set; }

    public static List<IResearch> ALL_RESEARCH
    {
        get
        {
            return new List<IResearch>()
            {
                /*Tier 1*/
                new ValueResearch(1, 1),
                /*Tier 2*/
                new HouseExpansion(2, 1),
                new DoubleValue(2, 2),
                /*Tier 3*/
            };
        }
    }

    MoneyManager m_moneyManager = null;

    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();

        BoughtResearch = new List<IResearch>();
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }

    public void BuyResearch(IResearch research)
    {
        if(m_moneyManager.Money >= research.Cost)
        {
            m_moneyManager.RemoveAmount(research.Cost);
        }
        else
        {
            Debug.Log("Unable to purchase research. Not enough money");
        }
    }

    public void SetResearch(List<IResearch> boughtResearches)
    {
        if(boughtResearches == null)
        {
            BoughtResearch.Clear();
        }
        else
        {
            BoughtResearch = boughtResearches;
        }
    }
}
