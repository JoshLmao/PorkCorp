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
    double ModifyValue { get; }
    /// <summary>
    /// The type of research this is. Sets where the modify value is sent to
    /// </summary>
    ResearchType Type { get; }
    /// <summary>
    /// The cost in currency to buy the research
    /// </summary>
    double Cost { get; }

    /// <summary>
    /// The number of times this research has been bought
    /// </summary>
    int AmountBought { get; }
    /// <summary>
    /// The maximum number of times this research can be bought
    /// </summary>
    int MaxAmountAllowed { get; }

    void Buy();
    /// <summary>
    /// Set loaded values from file
    /// </summary>
    void SetLoadedValues(int amountBought);
}