using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public Transform TargetTransform { get; private set; }

    void Start ()
    {
    }

    void Update ()
    {
    }

    public void SetTargetPosition(Transform t)
    {
        TargetTransform = t;
    }
}
