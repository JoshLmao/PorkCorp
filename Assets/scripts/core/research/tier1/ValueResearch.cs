using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueResearch : IResearch
{
    public int Tier { get { return 0; } }
    public int Order { get { return 0; } }

    public string Name { get { return "Increase Value"; } }
    public string Description { get { return "Increase pork value by 25%"; } }
    public double Value { get { return 0.25; } }
    public double Cost { get { return 0.40; } }
}
