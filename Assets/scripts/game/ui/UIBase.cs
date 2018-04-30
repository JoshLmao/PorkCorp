using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField]
    protected bool m_hideOnStart = true;

    bool m_isShowing = false;

    protected virtual void Awake()
    {
        if (m_hideOnStart && this.gameObject.activeInHierarchy)
            OnSetUI(false);
    }

    public virtual void OnToggleUI()
    {
        m_isShowing = !m_isShowing;
        OnSetUI(m_isShowing);
    }

    public virtual void OnSetUI(bool status)
    {
        this.gameObject.SetActive(m_isShowing);
    }
}
