using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    /// <summary>
    /// Use non static list to store the instances
    /// </summary>
    List<IResearch> m_allResearch = new List<IResearch>()
                                    {
                                        /*Tier 1*/
                                        new ValueResearch(1, 1),
                                        new FabricatorRecharge(1, 2),
                                        /*Tier 2*/
                                        new HouseExpansion(2, 1),
                                        new DoubleValue(2, 2),
                                        /*Tier 3*/
                                    };

    public List<IResearch> AllResearch
    {
        get { return m_allResearch; }
        private set { m_allResearch = value; }
    }

    MoneyManager m_moneyManager = null;

    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }

    public void BuyResearch(IResearch research)
    {
        if (m_moneyManager.Money < research.Cost)
        {
            Debug.Log("Unable to purchase research. Not enough money");
            return;
        }

        //Should be able to do with UI being disabled but add check just incase
        if (research.AmountBought >= research.MaxAmountAllowed)
        {
            Debug.Log("Unable to purchase research. Reached max bought");
            return;
        }

        m_moneyManager.RemoveAmount(research.Cost);
        research.Buy();
    }

    /// <summary>
    /// Sets all research to loaded values. Should only be set from loading from file
    /// </summary>
    /// <param name="allLoadedResearch">All loaded research</param>
    public void SetResearch(List<IResearch> allLoadedResearch)
    {
        if (allLoadedResearch == null || allLoadedResearch?.Count == 0)
            return;

        AllResearch = allLoadedResearch;
    }
}
