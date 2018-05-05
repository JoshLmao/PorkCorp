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

        UpdateList();
    }

    protected override void EntryAdded(GameObject entry, int tier, int entryIndex)
    {
        IResearch research = m_researchManager.AllResearch.FirstOrDefault(x => x.Tier == tier && x.Order == entryIndex);
    
        ResearchUserControl uc = entry.GetComponent<ResearchUserControl>();
        uc.DataContext = research;

        uc.Name = research != null ? research.Name : "Empty";
        uc.Description = research != null ? research.Description : "Non description";
        uc.Cost = research != null ? research.Cost : 0.0;
        uc.Icon = GetResearchSprite(research?.Name);
        uc.AmountBought = research != null ? research.AmountBought : 0;
        uc.MaxAmountAllowed = research != null ? research.MaxAmountAllowed : 1;

        uc.OnBuyResearch += OnPurchaseResearch;
    }

    private void OnPurchaseResearch(IResearch research)
    {
        m_researchManager.BuyResearch(research);
        UpdateList();
    }

    void UpdateList()
    {
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

        UpdateTieredList(tierAndEntryCount, true);
    }

    /// <summary>
    /// Gets the sprite from the resources
    /// </summary>
    /// <param name="spritePath"></param>
    /// <returns></returns>
    Sprite GetResearchSprite(string spritePath)
    {
        string resourcesBasePath = "research_sprites/";

        Sprite icon = null;
        if (!string.IsNullOrEmpty(spritePath))
        {
            spritePath = spritePath.Replace(" ", string.Empty);
            icon = Resources.Load<Sprite>(resourcesBasePath + spritePath.ToLower());
        }

        if (icon == null)
        {
            icon = Resources.Load<Sprite>(resourcesBasePath + "fallbackIcon");
            //Debug.Log($"Unable to find sprite for {spritePath}");
        }

        return icon;
    }
}
