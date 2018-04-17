using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerMinuteUpdater : MonoBehaviour
{
    [SerializeField]
    Text m_perMinText;

    MoneyManager m_moneyManager;

    private void Awake()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();

        if (m_perMinText == null)
            m_perMinText = GetComponent<Text>();

        if (m_perMinText == null)
            Debug.LogError("No PerMinute text found!");
    }

    private void Start ()
    {
        StartCoroutine(UpdateMoneyCoroutine());
    }

    private void Update ()
    {
        int currentValue = m_moneyManager.Money;
    }

    IEnumerator UpdateMoneyCoroutine()
    {
        float waitTimeMillis = 100f;

        float currentTime = Time.time;
        while (true)
        {
            UpdateMoneyPerMinute();
            currentTime += waitTimeMillis;
            yield return new WaitForFixedUpdate();
        }
    }

    void UpdateMoneyPerMinute()
    {
        m_perMinText.text = 0.0 + "/ SEC";
    }
}
