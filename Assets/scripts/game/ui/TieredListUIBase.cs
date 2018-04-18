using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TieredListUIBase : ListUIBase
{
    [SerializeField]
    GameObject m_uiTierTitlePrefab;

    [SerializeField]
    protected float m_uiTierSpacing = 10f;

    protected virtual void UpdateTieredList(Dictionary<int, int> tiersAndEntryCounts)
    {
        DestroyChildren(m_listParent);

        if (m_uiEntries == null)
            m_uiEntries = new List<GameObject>();
        else if (m_uiEntries.Count > 0)
            m_uiEntries.Clear();

        float currentY = m_uiStartYPosition;
        foreach (int tier in tiersAndEntryCounts.Keys)
        {
            GameObject tierUI = Instantiate(m_uiTierTitlePrefab, m_listParent);
            Text tierText = tierUI.GetComponent<Text>();
            tierText.text = "TIER " + tier;

            SetRectLocalPos(tierUI, currentY);
            currentY -= m_uiTierSpacing;

            for (int entry = 0; entry < tiersAndEntryCounts[tier]; entry++)
            {
                GameObject ui = Instantiate(m_uiEntryPrefab, m_listParent);

                SetRectLocalPos(ui, currentY);
                currentY -= m_uiEntrySpacing;
                EntryAdded(ui, tier, entry);
            }
        }
    }

    protected virtual void EntryAdded(GameObject entry, int tier, int entryIndex)
    {

    }
}
