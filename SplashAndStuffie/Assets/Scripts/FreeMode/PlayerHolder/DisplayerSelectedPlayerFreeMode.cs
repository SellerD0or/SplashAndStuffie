using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerSelectedPlayerFreeMode : MonoBehaviour
{
    public PlayerIconFreeModeScene LastPlayerIcon { get; set; }
    [SerializeField] private BackgroundOfCardFreeMode _background;
    [SerializeField] private GetterGemFreeMode _getterGem;
   private PlayerInformationFreeMode _player;
    [SerializeField] private Image _image;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private CameraFreeMode _cameraFreeMode;

    public CameraFreeMode CameraFreeMode { get => _cameraFreeMode; set => _cameraFreeMode = value; }
    public  bool HavePlayer { get;  set; }
    public PlayerInformationFreeMode Player { get => _player; set => _player = value; }
    public GetterGemFreeMode GetterGem { get => _getterGem; set => _getterGem = value; }
    public BackgroundOfCardFreeMode Background { get => _background; set => _background = value; }

    public void Display(PlayerInformationFreeMode player)
    {
        Player = player;
        _image.sprite = Player.GetComponent<Player>().BarIcon;
        Appear();
    }
    public void Appear()
    {
        HavePlayer = true;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 1;
    }
    public void Disappear()
    {
        HavePlayer = false;
        Player = null;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 0;
    }
    private void Update() {
        _image.transform.position = Input.mousePosition;
    }
}
