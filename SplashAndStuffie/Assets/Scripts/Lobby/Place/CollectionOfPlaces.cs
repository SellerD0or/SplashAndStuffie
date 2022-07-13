using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionOfPlaces 
{
    public static List<Place> Places = new List<Place>();
    public static void AddPlace(this Place place)
    {
        Places.Add(place);
    }
}
