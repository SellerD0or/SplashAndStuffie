using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RedactorButton : MonoBehaviour
{
   public abstract void Open();
   public abstract void Close();
   public abstract void ChangeStateOfRedactorButton();
}
