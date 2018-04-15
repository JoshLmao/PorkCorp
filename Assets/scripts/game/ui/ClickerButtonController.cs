using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Button m_clickerBtn;

    bool m_isHoldingBtn = false;
    FabricatorManager m_fabricatorManager = null;

    double m_autoClickerMultiplier = 0.0;

    DateTime m_mouseDownTime = DateTime.MinValue;

    #region MonoBehavious
    private void Awake()
    {
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
        if (m_fabricatorManager == null)
            Debug.LogError("Unable to find fabricator manager! Can't create pigs on click");
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (m_isHoldingBtn && m_autoClickerMultiplier > 0.0)
        {
            m_fabricatorManager.CreatePig();
        }
    }
    #endregion

    public void OnPointerDown(PointerEventData eventData)
    {
        m_isHoldingBtn = true;
        m_mouseDownTime = DateTime.Now;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Will need diff method...
        TimeSpan mouseDownDiff = DateTime.Now - m_mouseDownTime;
        if (!m_isHoldingBtn || mouseDownDiff.TotalMilliseconds < 100)
        {
            m_fabricatorManager.CreatePig();
        }

        m_isHoldingBtn = false;
    }
}
