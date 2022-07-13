using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicAmulet : Amulet
{
    public override ArtifactRarity Rarity { get ; set ; } = ArtifactRarity.Epic;
    public override ArtifactInfo ArtifactInfo { get ; set ; }
    private void Start() {
        ArtifactInfo = GetComponent<ArtifactInfo>();
    }
}
