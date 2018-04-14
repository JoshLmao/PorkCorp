using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerButtonController : MonoBehaviour {

    [SerializeField]
    Button m_clickerBtn;

    bool m_isHoldingBtn = false;
    FabricatorManager m_fabricatorManager = null;

    void Awake()
    {
        m_fabricatorManager = FindObjectOfType<FabricatorManager>();
        if (m_fabricatorManager == null)
            Debug.LogError("Unable to find fabricator manager! Can't create pigs on click");
    }

    void Start ()
    {
        if(m_clickerBtn != null)
        {
            m_clickerBtn.onClick.AddListener(OnClicked);
        }
        else
        {
            Debug.LogError("Unable to listen to click UI events. No Btn set!");
        }
    }

    void Update ()
    {
		
	}

    private void OnClicked()
    {
        m_fabricatorManager.CreatePig();
    }
}
