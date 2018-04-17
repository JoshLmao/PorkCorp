using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListUIBase : MonoBehaviour
{
    [SerializeField]
    bool m_hideOnStart = true;

    [SerializeField]
    protected Transform m_listParent;

    [SerializeField]
    protected GameObject m_uiEntryPrefab;

    [SerializeField]
    protected float m_uiStartYPosition = 0f;

    [SerializeField]
    protected float m_uiSpacing = 10f;

    protected List<GameObject> m_uiEntries = null;

    protected virtual void Awake()
    {
        if (m_uiEntryPrefab == null)
            Debug.LogError("List UI entry prefab is null");

        if(m_hideOnStart)
            OnHideUI();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void UpdateVehicleList(int entryCount)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform existingChildren in m_listParent)
            Destroy(existingChildren.gameObject);

        if (m_uiEntries == null)
            m_uiEntries = new List<GameObject>();
        else if (m_uiEntries.Count > 0)
            m_uiEntries.Clear();

        float currentY = m_uiStartYPosition;
        for (int i = 0; i < entryCount; i++)
        {
            GameObject ui = Instantiate(m_uiEntryPrefab, m_listParent);

            ui.GetComponent<RectTransform>().localPosition = new Vector3(ui.transform.localPosition.x, currentY, ui.transform.localPosition.z);
            currentY -= m_uiSpacing; //gap between UI
            EntryAdded(ui, i);

            m_uiEntries.Add(ui);
        }
    }

    protected virtual void EntryAdded(GameObject entry, int index)
    {

    }

    public virtual void OnShowUI()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void OnHideUI()
    {
        this.gameObject.SetActive(false);
    }
}
