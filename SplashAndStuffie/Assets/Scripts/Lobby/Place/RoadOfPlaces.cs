using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadOfPlaces : MonoBehaviour
{
  [SerializeField] private List<Place> _places;

    public List<Place> Places { get => _places; set => _places = value; }
    private void OnEnable() {
        foreach (var place in Places)
        {
            place.Mesh.enabled =false;
        }
    }
}
