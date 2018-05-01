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

        float currentY = m_uiStartLocalYPosition;
        float newCanvasHeight = 0f;
        foreach (int tier in tiersAndEntryCounts.Keys)
        {
            GameObject tierUI = Instantiate(m_uiTierTitlePrefab, m_listParent);
            Text tierText = tierUI.GetComponent<Text>();
            tierText.text = "TIER " + tier;

            newCanvasHeight += tierUI.GetComponent<RectTransform>().rect.height + m_uiTierSpacing;

            SetRectLocalPos(tierUI, currentY);
            currentY -= (tierUI.GetComponent<RectTransform>().rect.height + m_uiTierSpacing);

            for (int entry = 0; entry < tiersAndEntryCounts[tier]; entry++)
            {
                GameObject ui = Instantiate(m_uiEntryPrefab, m_listParent);
                SetRectLocalPos(ui, currentY);

                float heightAndPadding = (ui.GetComponent<RectTransform>().rect.height + m_uiEntrySpacing);
                currentY -= heightAndPadding;
                newCanvasHeight += heightAndPadding;
                EntryAdded(ui, tier, entry + 1);
            }
        }

        SetRectHeight(newCanvasHeight);
        SetScrollRect(m_resizeCanvas.GetComponentInParent<ScrollRect>());
    }

    protected virtual void EntryAdded(GameObject entry, int tier, int order)
    {

    }

    void SetScrollRect(ScrollRect rect)
    {
        if (rect != null)
        {
            rect.verticalNormalizedPosition = 1f;
        }
    }
}
