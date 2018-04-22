using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerMinuteUpdater : MonoBehaviour
{
    [SerializeField]
    Text m_perMinText;

    MoneyManager m_moneyManager;
    double m_previousMoney = 0.0;

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
    }

    IEnumerator UpdateMoneyCoroutine()
    {
        float waitTimeMillis = 100f;

        float currentTime = Time.time;
        while (true)
        {
            UpdateMoneyPerMinute(0.0);
            currentTime += waitTimeMillis;
            yield return new WaitForFixedUpdate();
        }
    }

    void UpdateMoneyPerMinute(double value)
    {
        m_perMinText.text = value + "/ SEC";
    }
}
