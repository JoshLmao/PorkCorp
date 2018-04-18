using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResearch
{
    /// <summary>
    /// The tier this research is in
    /// </summary>
    int Tier { get; }
    /// <summary>
    /// The order in the tier this research is in
    /// </summary>
    int Order { get; }

    string Name { get; }
    string Description { get; }
    double Value { get; }
    double Cost { get; }
}