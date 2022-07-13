using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyItem : Item
{
    public override ArtifactRarity Rarity { get ; set ; } = ArtifactRarity.None;
    public override ArtifactInfo ArtifactInfo { get ; set ; }
}
