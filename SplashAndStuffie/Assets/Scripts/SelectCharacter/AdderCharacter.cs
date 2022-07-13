using System.Runtime.InteropServices;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdderCharacter : MonoBehaviour
{
        [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private GameObject[] _stars;

    [SerializeField] private SelecterCharacterScrollRect _selecterCharacterScrollRect;
    [SerializeField] private GameObject _plus;
    private List<SelectablePlayer>  _selectablePlayers= new List<SelectablePlayer>();

    public List<SelectablePlayer> SelectablePlayers { get => _selectablePlayers; set => _selectablePlayers = value; }
    public LoaderSaveableSlotOfCharacter Loader { get => _loader; set => _loader = value; }
    public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
    [SerializeField] private Text _text;
    private Player _currentPlayer;
    public event UnityAction OnAdd;
    private LoaderSaveableSlotOfCharacter _loader;
    [SerializeField] private CanvasGroup _slot;
    [SerializeField] private LocalizationText _localization;
    private void Start() {
        _selecterCharacterScrollRect = FindObjectOfType<SelecterCharacterScrollRect>();
        _loader = FindObjectOfType<LoaderSaveableSlotOfCharacter>();
        
    }
    public void Add()
   {
       _selecterCharacterScrollRect.ChangeCanvasGroup(1,true);
       _loader.CreatorAdderCharacter.CurrentAdderCharacter = this;
       OnAdd?.Invoke();
   }
   public void Choose(SlotOfCharacter _slotOfCharacter)
   {
      Player player = Instantiate(_slotOfCharacter.Player, transform.position,Quaternion.identity);
      player.gameObject.SetActive(true);
      player.transform.localScale = new Vector3(0.4832574f,0.4832574f,69);
        if (player is Axel)
      {
          player.transform.position = new Vector3(player.transform.position.x,-1.42f , player.transform.position.z);
      }
      player.transform.SetParent(_loader.CreatorAdderCharacter.CurrentAdderCharacter.transform);
      player.GetComponent<SortingGroup>().sortingOrder = 1;
      CurrentPlayer = player;
      _text.text = CurrentPlayer.Name;
      _slot.alpha = 1;
      _slot.blocksRaycasts = true;
     // player.IPlayerAnimator.EnemyAnimator._sortingOrder = 1;
      //player.transform.SetParent(_plus.transform);
      _plus.SetActive(false);
       for (int i = 0; i < CurrentPlayer.LevelOfPlayer +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[CurrentPlayer.LevelOfPlayer];

        }
        _localization.Key = CurrentPlayer.Name;
        _localization.Display();
       _selecterCharacterScrollRect.ChangeCanvasGroup(0,false);
   }
}
