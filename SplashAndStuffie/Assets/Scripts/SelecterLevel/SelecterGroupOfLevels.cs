using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecterGroupOfLevels : MonoBehaviour
{
    [SerializeField] private SelectedGroupOfLevels _groupOfLevels;
    [SerializeField] private Transform _canvasPosition;
    public void OnClick()
    {
       SelectedGroupOfLevels groupOfLevels = Instantiate(_groupOfLevels,new Vector3(0,0,0), Quaternion.identity);
       groupOfLevels.transform.SetParent(_canvasPosition,false);
    }
}
