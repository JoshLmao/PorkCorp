using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        foreach(IResearch research in m_researchManager.AllResearch)
        {

        }

        UpdateTieredList(null);
    }

    protected override void EntryAdded(GameObject entry, int tier, int entryIndex)
    {
        IResearch research = null;

        ResearchUserControl uc = entry.GetComponent<ResearchUserControl>();
        uc.DataContext = research;

        uc.Name = research != null ? research.Name : "Empty";
        uc.Description = research != null ? research.Description : "Non desc";
        uc.Cost = research != null ? research.Cost : 0.0;
        uc.Icon = null;
    }
}
