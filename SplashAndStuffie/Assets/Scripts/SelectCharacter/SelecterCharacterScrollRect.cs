using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecterCharacterScrollRect : MonoBehaviour
{
  [SerializeField] private CanvasGroup _canvasGroup;

    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
    public void ChangeCanvasGroup(int alpha, bool blockRaycats)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.blocksRaycasts = blockRaycats;
    }
}
