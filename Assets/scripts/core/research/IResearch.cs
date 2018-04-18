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

    /// <summary>
    /// The display name of the research
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The display discription of the research
    /// </summary>
    string Description { get; }
    /// <summary>
    /// The internal value used to do the research modification
    /// </summary>
    double Value { get; }
    /// <summary>
    /// The cost in currency to buy the research
    /// </summary>
    double Cost { get; }
}