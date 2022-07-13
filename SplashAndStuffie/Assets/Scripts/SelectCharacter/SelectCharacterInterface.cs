using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterInterface : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _iconOfTypeOfPlayer;
    [SerializeField] private LocalizationText _nameOfCharacter;
    [SerializeField] private LocalizationText _decriptionOfCharacter;
    [SerializeField] private Sprite[] _spritesOfTypeOfPlayer;

    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }

    public void SetPlayer(Player player)
    {
        _nameOfCharacter.Key = player.Name;
        _nameOfCharacter.Display();
        _decriptionOfCharacter.Key = player.MiniDescription;
        _decriptionOfCharacter.Display();
        if (CanvasGroup.alpha == 0)
        {
            CanvasGroup.alpha = 1;
        }
        _iconOfTypeOfPlayer.sprite = _spritesOfTypeOfPlayer[(int) player.TypeOfPlayer];
    }
    public void RemovePlayer()
    {
        if (CanvasGroup.alpha ==1)
        {
            CanvasGroup.alpha =0;
        }
    }
}
