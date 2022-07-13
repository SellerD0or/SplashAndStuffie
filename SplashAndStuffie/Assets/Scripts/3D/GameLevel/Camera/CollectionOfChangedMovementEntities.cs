using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class CollectionOfChangedMovementEntities 
{
    public static List<IChangedMovementEntity> IChangedMovementEntities = new List<IChangedMovementEntity>();
  public static void Add(this IChangedMovementEntity entity)
  {
      IChangedMovementEntities.Add(entity);
  }
}
