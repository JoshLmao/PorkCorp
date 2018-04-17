using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int Money { get; private set; }
    public double SellValue { get; private set; }

    public MoneyManager()
    {
        Money = 0;
        SellValue = 0.10;
    }

    void Awake()
    {
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
