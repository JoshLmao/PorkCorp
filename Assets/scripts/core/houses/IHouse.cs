public interface IHouse
{
    /// <summary>
    /// The unique name of the house
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The base cost to buy the house
    /// </summary>
    double BaseCost { get; }
    /// <summary>
    /// The base capacity the house can hold, excluding research
    /// </summary>
    int BaseTotalCapacity { get; }
    /// <summary>
    /// The total number of pigs that can be currently inside the house
    /// </summary>
    int TotalCapacity { get; set; }
    /// <summary>
    /// The number of pigs currently inside this house
    /// </summary>
    int CurrentCapacity { get; set; }
    /// <summary>
    /// The amount of pigs currently in transit to the house
    /// </summary>
    int TransitCount { get; set; }
    
    /// <summary>
    /// The amount of pigs to be created every elapse
    /// </summary>
    int PassiveBreedAmount { get; set; }
    /// <summary>
    /// The milliseconds interval between adding passive breeding
    /// </summary>
    double BasePassiveBreedInterval { get; }
    /// <summary>
    /// The current breed interval
    /// </summary>
    double CurrentPassiveBreedInterval { get; set; }

    int HouseIndex { get; set; }

    void IncreaseTotalCapacity(int amount);
}