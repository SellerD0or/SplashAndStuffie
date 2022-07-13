using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtisShopCharactersBoard : MonoBehaviour
{
    [SerializeField] private List<OtisShopMiniCharacterBoard> _boards;
    [SerializeField] private Image _image;
    private bool _isEnter;

    public Image Image { get => _image; set => _image = value; }

    private void Start() {
        Image.enabled = false;
    }
    public void OnPointExit()
    {
        Debug.LogError("LEFt US");
       _isEnter = false;
       Invoke(nameof(OnExit),3);
    }
    public void OnExit()
    {
        if(_isEnter == false)
        {
         foreach (var item in _boards)
         {
             item.CanTouch = true;
            item.MoveForwmard();
         }
        Image.enabled = false;
        }
    }

    public void OnPointerEnter()
    {
        Debug.Log("JPIM US");
        _isEnter = true;
    }
}
