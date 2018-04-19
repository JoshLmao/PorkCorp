using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public abstract class HouseBase : MonoBehaviour, IHouse
{
    public virtual int TotalCapacity { get; private set; }

    [SerializeField]
    private int m_currentCapacity = 0;
    public int CurrentCapacity
    {
        get { return (int)m_currentCapacity; }
        set { m_currentCapacity = value; }
    }

    public double PigsPerSecond { get; set; }

    Timer m_breedTimer = null;
    MoneyManager m_moneyManager = null;

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
    }

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
        if(CurrentCapacity > 0)
        {
            m_moneyManager.AddAmount(GetAmount());
        }
    }

    private void OnBreedPigsElapsed(object sender, ElapsedEventArgs e)
    {
        if(PigsPerSecond > 0.0)
        {
            //if(CurrentCapacity + (int)PigsPerSecond <= TotalCapacity)
            //    CurrentCapacity += (int)PigsPerSecond;
        }
    }

    public virtual void AddPigs(int amount)
    {
        CurrentCapacity += amount;
        UpdateBreedRate();
    }

    void UpdateBreedRate()
    {
        //Increment breed rate by making one child per pair
        int pairs = CurrentCapacity % 2 == 1 ? CurrentCapacity - 1 : CurrentCapacity;
        PigsPerSecond = pairs / 2;
    }

    double GetAmount()
    {
        return m_moneyManager.SellValue * (CurrentCapacity * Time.fixedDeltaTime);
    }
}
