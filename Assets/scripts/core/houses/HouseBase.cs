using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public abstract class HouseBase : MonoBehaviour, IHouse
{
    public abstract int TotalCapacity { get; }

    [SerializeField]
    private int m_currentCapacity = 0;
    public int CurrentCapacity
    {
        get { return m_currentCapacity; }
        set { m_currentCapacity = 0; }
    }

    public double BreedRate { get; set; }

    Timer m_breedTimer = null;

    protected virtual void Awake()
    {
        m_breedTimer = new Timer(1000);
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
        if(BreedRate > 0.0)
        {

        }
    }

    public virtual void AddPig()
    {
        CurrentCapacity++;
    }
}
