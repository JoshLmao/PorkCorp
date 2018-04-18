using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResearch
{
    int Tier { get; }
    string Name { get; }
    string Description { get; }
    double Value { get; }
    double Cost { get; }
}