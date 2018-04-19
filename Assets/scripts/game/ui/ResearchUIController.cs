using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResearchUIController : TieredListUIBase
{
    ResearchManager m_researchManager = null;

    protected override void Awake()
    {
        base.Awake();

        m_researchManager = FindObjectOfType<ResearchManager>();
    }

    protected override void Start()
    {
        base.Start();

        Dictionary<int, int> tierAndEntryCount = new Dictionary<int, int>();
        foreach (IResearch research in m_researchManager.AllResearch)
        {
            if (tierAndEntryCount.ContainsKey(research.Tier))
            {
                if (tierAndEntryCount[research.Tier] < research.Order)
                    tierAndEntryCount[research.Tier] = research.Order;
            }
            else
            {
                tierAndEntryCount.Add(research.Tier, research.Order);
            }
        }

        UpdateTieredList(tierAndEntryCount);
    }

    protected override void EntryAdded(GameObject entry, int tier, int entryIndex)
    {
        IResearch research = m_researchManager.AllResearch.FirstOrDefault(x => x.Tier == tier && x.Order == entryIndex);

        ResearchUserControl uc = entry.GetComponent<ResearchUserControl>();
        uc.DataContext = research;

        uc.Name = research != null ? research.Name : "Empty";
        uc.Description = research != null ? research.Description : "Non desc";
        uc.Cost = research != null ? research.Cost : 0.0;
        uc.Icon = null;

        uc.OnBuyResearch += OnPurchaseResearch;
    }

    private void OnPurchaseResearch(IResearch research)
    {
        m_researchManager.BuyResearch(research);
    }
}
