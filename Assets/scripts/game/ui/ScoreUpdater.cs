using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField]
    Text m_moneyText;

    MoneyManager m_moneyManager = null;

	void Start ()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();
        if (m_moneyManager == null)
            Debug.LogError("Unable to find MoneyManager! Can't update score");
    }

    void Update ()
    {
        m_moneyText.text = m_moneyManager.Money.ToString();
    }
}
