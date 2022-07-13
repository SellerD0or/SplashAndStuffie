using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelTargetFreeMode : MonoBehaviour
{
    public void SetPosition(Vector3 pos)
    {
        Debug.LogError(pos + " Coool shoot ");
        transform.position = pos;
    }
}
