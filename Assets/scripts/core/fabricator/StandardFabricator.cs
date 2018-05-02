using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFabricator : FabricatorController
{
    public override MeatLevel Level { get { return MeatLevel.Standard; } }
}
