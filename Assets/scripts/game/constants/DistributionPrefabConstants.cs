using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionPrefabConstants : MonoBehaviour
{
    [SerializeField]
    GameObject m_estatePrefab;

    public static GameObject EstatePrefab { get; private set; }

    public DistributionPrefabConstants()
    {
        EstatePrefab = m_estatePrefab;
    }
}
