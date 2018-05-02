using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricatorController : MonoBehaviour
{
    public virtual MeatLevel Level { get; }

    [SerializeField]
    Transform m_pigSpawnLocation;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    public Transform GetSpawnLocation()
    {
        return m_pigSpawnLocation;
    }
}
