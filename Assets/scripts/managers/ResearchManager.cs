using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    public List<IResearch> BoughtResearch { get; private set; }

    public List<IResearch> AllResearch
    {
        get
        {
            return new List<IResearch>()
            {
                new ValueResearch(),
            };
        }
    }

    private void Awake()
    {
    }

    private void Start ()
    {
    }

    private void Update ()
    {
    }

    public void BuyResearch(IResearch research)
    {

    }
}
