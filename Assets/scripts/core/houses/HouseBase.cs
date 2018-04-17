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
        get { return m_currentCapacity; }
        set { m_currentCapacity = value; }
    }

    public double PigsPerSecond { get; set; }

    Timer m_breedTimer = null;

    /// <summary>
    /// The duration in seconds for pigs to breed at and create child pigs
    /// </summary>
    const int BASE_BREED_DURATION_SECONDS = 1;

    protected virtual void Awake()
    {
        m_breedTimer = new Timer((BASE_BREED_DURATION_SECONDS * 1000));
        m_breedTimer.Elapsed += OnBreedPigsElapsed;
        m_breedTimer.Start();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
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
}
