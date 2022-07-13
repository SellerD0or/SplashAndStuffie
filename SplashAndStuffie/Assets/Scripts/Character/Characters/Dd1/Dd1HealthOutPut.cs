using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthOutput))]
public class Dd1HealthOutPut : MonoBehaviour, IHealthOutPut
{
  public HealthOutput HealthOutput { get ; set ; }
    private void Start() {
        HealthOutput = GetComponent<HealthOutput>();
    }
}
