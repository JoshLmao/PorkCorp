using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListUIBase : UIBase
{
    [SerializeField]
    protected Transform m_listParent;

    [SerializeField]
    protected GameObject m_uiEntryPrefab;

    [SerializeField]
    protected float m_uiStartLocalYPosition = 0f;

    [SerializeField]
    protected float m_uiEntrySpacing = 10f;

    [SerializeField]
    protected float m_minRectHeight;

    [SerializeField]
    protected RectTransform m_resizeCanvas;

    protected List<GameObject> m_uiEntries = null;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void UpdateList(int entryCount)
    {
        DestroyChildren(m_listParent);
        //Workaround: Set height to min to position all correctly
        SetRectHeight(m_minRectHeight);

        if (m_uiEntries == null)
            m_uiEntries = new List<GameObject>();
        else if (m_uiEntries.Count > 0)
            m_uiEntries.Clear();

        float currentY = m_uiStartLocalYPosition;
        float newCanvasHeight = 0f;
        for (int i = 0; i < entryCount; i++)
        {
            GameObject ui = Instantiate(m_uiEntryPrefab, m_listParent);

            SetRectLocalPos(ui, currentY);
            currentY -= (ui.GetComponent<RectTransform>().rect.height + m_uiEntrySpacing);
            EntryAdded(ui, i);

            newCanvasHeight += ui.GetComponent<RectTransform>().rect.height + m_uiEntrySpacing;

            m_uiEntries.Add(ui);
        }

        SetRectHeight(newCanvasHeight);
        SetScrollRect(m_resizeCanvas.GetComponentInParent<ScrollRect>());
    }

    protected virtual void EntryAdded(GameObject entry, int index)
    {

    }

    protected void SetRectLocalPos(GameObject ui, float yPos)
    {
        ui.GetComponent<RectTransform>().localPosition = new Vector3(ui.transform.localPosition.x, yPos, ui.transform.localPosition.z);
    }

    protected void DestroyChildren(Transform parent)
    {
        foreach (Transform existingChildren in parent)
            Destroy(existingChildren.gameObject);
    }

    protected void SetRectHeight(float rectHeight)
    {
        if (rectHeight < m_minRectHeight)
            rectHeight = m_minRectHeight;
        RectTransform rect = m_resizeCanvas.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0, rectHeight);
    }

    public override void OnSetUI(bool status)
    {
        base.OnSetUI(status);

        if (status)
        {
            SetScrollRect(m_resizeCanvas.GetComponentInParent<ScrollRect>());
        }
    }

    void SetScrollRect(ScrollRect rect)
    {
        if (rect != null)
        {
            rect.verticalNormalizedPosition = 1f;
        }
    }
}
