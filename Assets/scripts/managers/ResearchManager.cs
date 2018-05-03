using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
                                        new IncreaseVehicleLimit(2, 3),
                                        /*Tier 3*/
                                    };

    /// <summary>
    /// All research bought
    /// </summary>
    public List<IResearch> AllResearch
    {
        get { return m_allResearch; }
        private set { m_allResearch = value; }
    }

    MoneyManager m_moneyManager = null;
    FabricatorManager m_fabricatorManager = null;
    HousingManager m_housingManager = null;
    DistributionManager m_distributionManager = null;

    #region MonoBehavious
    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
        m_housingManager = FindObjectOfType<HousingManager>();
        m_distributionManager = FindObjectOfType<DistributionManager>();
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }
    #endregion

    /// <summary>
    /// Purchase a research. Handles applying research & removing money
    /// </summary>
    /// <param name="research">The reseaerch to buy</param>
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

        ApplyModifyValue(research);
    }

    /// <summary>
    /// Sets the research value to the appropriate location
    /// </summary>
    /// <param name="research">The research to apply</param>
    void ApplyModifyValue(IResearch research)
    {
        switch(research.Type)
        {
            //Fabricator Researches
            case ResearchType.FabricatorChargeRate:
                m_fabricatorManager.IncreaseChargeRate(research.ModifyValue);
                break;
            case ResearchType.FabricatorMaxCharge:
                m_fabricatorManager.IncrementMaxCharge(research.ModifyValue);
                break;
            //Money Researches
            case ResearchType.MoneyIncreaseValue:
                m_moneyManager.IncreaseResearchValue(research.ModifyValue);
                break;
            case ResearchType.MoneyUniqueMultiply:
                m_moneyManager.AddUniqueMultiplier(research.ModifyValue);
                break;
            //Housing Researches
            case ResearchType.HousingIncreaseCapacity:
                m_housingManager.IncreaseCapacitiesByPercent(research.ModifyValue);
                break;
            case ResearchType.HousingIncreasePassiveBreedRate:
                m_housingManager.IncreasePassiveBreedAmounts((int)research.ModifyValue);
                break;
            case ResearchType.HousingLayInterval:
                m_housingManager.DecreaseLayIntervals(research.ModifyValue);
                break;
            //Distribution Researches
            case ResearchType.DistributionVehicleCapacity:
                m_distributionManager.IncreaseVehicleCapacity((int)research.ModifyValue);
                break;
            case ResearchType.DistributionVehicleSellRate:
                m_distributionManager.IncreaseVehicleSellRates((int)research.ModifyValue);
                break;
            case ResearchType.DistributionVehicleLimit:
                m_distributionManager.IncreaseVehicleLimit((int)research.ModifyValue);
                break;
            default:
                throw new NotImplementedException("Not implemented research value");
        }
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

        //Go over every research
        foreach (IResearch research in AllResearch)
        {
            //Dont apply these researches since loaded file contains applied research from prev. game values
            if (research.Type == ResearchType.HousingIncreaseCapacity)
                continue;

            //Debug.Log($"Research {research.Name} - Amount {research.AmountBought}");

            //Apply for each time bought. Since no research has been set yet, apply them all
            for (int i = 0; i < research.AmountBought; i++)
                ApplyModifyValue(research);
        }
    }
}
