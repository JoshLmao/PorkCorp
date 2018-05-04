using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : ListUIBase
{
    [SerializeField]
    Button m_resetProgressBtn;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        m_resetProgressBtn.onClick.AddListener(OnResetProgress);
    }

    private void OnResetProgress()
    {
        Debug.Log("Deleting save game data");
        FindObjectOfType<SaveManager>().RemoveSaveData();
        Application.Quit();
    }
}
