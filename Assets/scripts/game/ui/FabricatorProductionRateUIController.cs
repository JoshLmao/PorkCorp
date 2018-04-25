using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FabricatorProductionRateUIController : MonoBehaviour
{
    [SerializeField]
    Slider m_rateSlider;

    FabricatorManager m_fabricatorManager;

    private void Awake()
    {
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(m_fabricatorManager != null)
        {
            m_rateSlider.value = m_fabricatorManager.Charge;
            m_rateSlider.maxValue = m_fabricatorManager.ChargeCapacity;
        }
    }
}
