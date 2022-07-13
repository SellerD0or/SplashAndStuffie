using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonCoolTemptation : CoolTemptation
{
    public override ArtifactRarity Rarity { get ; set ; } = ArtifactRarity.Common;
  public override ArtifactInfo ArtifactInfo { get ; set ; }
}
