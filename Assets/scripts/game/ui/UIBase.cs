using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField]
    protected bool m_hideOnStart = true;

    protected virtual void Awake()
    {
        if (m_hideOnStart)
            OnHideUI();
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
