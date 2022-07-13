using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Infinity;
            RaycastHit2D hit2D = Physics2D.Raycast(mousePosition ,mousePosition - Camera.main.ScreenToWorldPoint(mousePosition), Mathf.Infinity);
            if(hit2D.collider != null)
            {
             if (hit2D.collider.GetComponent<ClickableCharacter>())
             {
                Debug.LogError("COol");
             }
            }
        }
    }
}
