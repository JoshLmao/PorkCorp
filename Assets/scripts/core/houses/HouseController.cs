using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public string Name { get { return this.name; } }

    public int TotalCapacity { get { return HouseInfo.TotalCapacity; } }
    public int HouseIndex
    {
        get { return HouseInfo.HouseIndex; }
        set { HouseInfo.HouseIndex = value; }
    }

    [SerializeField]
    private int m_currentCapacity = 0;
    public int CurrentCapacity
    {
        get { return HouseInfo.CurrentCapacity; }
        set
        {
            m_currentCapacity = value;
            HouseInfo.CurrentCapacity = value;
        }
    }

    public IHouse HouseInfo { get; private set; }

    [SerializeField]
    Transform m_npcWalkToPosition;

    MoneyManager m_moneyManager = null;
    Timer m_passiveBreedTimer;

    /// <summary>
    /// The duration in seconds for pigs to breed at and create child pigs
    /// </summary>
    const int BASE_BREED_DURATION_SECONDS = 1;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        m_moneyManager = FindObjectOfType<MoneyManager>();

        m_passiveBreedTimer = new Timer(HouseInfo.BasePassiveBreedInterval);
        m_passiveBreedTimer.Elapsed += OnBreedPigsElapsed;
        m_passiveBreedTimer.Start();
    }

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
    }

    private void OnBreedPigsElapsed(object sender, ElapsedEventArgs e)
    {
        if (HouseInfo != null)
        {
            CurrentCapacity += HouseInfo.PassiveBreedAmount;
        }
    }

    public virtual void AddPigs(int amount)
    {
        CurrentCapacity += amount;
    }

    double GetAmount()
    {
        Debug.Log(Time.fixedDeltaTime);
        return m_moneyManager.SellValue * (CurrentCapacity * Time.fixedDeltaTime);
    }

    public void SetInfo(IHouse houseInfo)
    {
        HouseInfo = houseInfo;
    }

    public Transform GetWalkToPosition()
    {
        if (m_npcWalkToPosition == null)
            Debug.LogError($"WalkToPosition hasn't been set on Prefab {HouseInfo.Name}");
        return m_npcWalkToPosition;
    }

    public void DecreasePassivePigRate(double percentValue)
    {
        if(m_passiveBreedTimer != null)
        {
            double newInterval = HouseInfo.CurrentPassiveBreedInterval / 1000 * percentValue;

            m_passiveBreedTimer.Stop();
            m_passiveBreedTimer.Interval = newInterval;
            m_passiveBreedTimer.Start();
        }
    }

    public void IncreasePassiveBreedAmount(int amount)
    {
        HouseInfo.PassiveBreedAmount += amount;
    }
}
