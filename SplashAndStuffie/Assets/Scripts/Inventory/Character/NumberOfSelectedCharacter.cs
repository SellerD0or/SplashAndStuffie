using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfSelectedCharacter : MonoBehaviour
{
   private LoaderSaveableSlotOfCharacter _loader;
  [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private Text _text;
   private Player _player;
    public LoaderSaveableSlotOfCharacter Loader { get => _loader; set => _loader = value; }
    public Player Player { get => _player; set => _player = value; }

    public void Open()
    {
        ChangeActive(1);
        Loader.NumberOfSelectedCharacter++;
        Loader.ChooseCurrentCharacter(Player);
        Loader.CurrentPlayers.Add(Player);
        _text.text = Loader.NumberOfSelectedCharacter.ToString();
    }
    public void Close()
    {
        ChangeActive(0);
        Loader.NumberOfSelectedCharacter = 0;
        Loader.CurrentPlayers.Clear();
        _text.text ="0";
    }
    private  void ChangeActive(float alpha)
    {
        _canvasGroup.alpha = alpha;
    }
}
