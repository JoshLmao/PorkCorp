using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sty : HouseBase
{
    public static string NAME { get { return "Sty"; } }

    public override string Name { get { return NAME; } }
    public override int TotalCapacity { get { return 250; } }

    public Sty()
    {

    }
}
