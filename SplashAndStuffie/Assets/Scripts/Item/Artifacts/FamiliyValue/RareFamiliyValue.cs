using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareFamiliyValue : FamiliyValue
{
       public override ArtifactRarity Rarity { get ; set ; } = ArtifactRarity.Rare;
  public override ArtifactInfo ArtifactInfo { get ; set ; }

}
