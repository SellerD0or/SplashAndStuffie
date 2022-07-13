using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareAmulet : Amulet
{
   public override ArtifactRarity Rarity { get ; set ; } = ArtifactRarity.Rare;
  public override ArtifactInfo ArtifactInfo { get ; set ; }
  private void Start() {
        ArtifactInfo = GetComponent<ArtifactInfo>();
    }
}
