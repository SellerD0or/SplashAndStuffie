using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIconFreeModeScene : MonoBehaviour
{
  public int Damage { get; set; } = 1;
  public int Health { get; set; } = 1;
   [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private GameObject[] _stars;
  private int _currentCountOfMoneyForBuying;
    //[SerializeField] private PlayerHolderFreeMode _playerHolderFreeMode;
      [SerializeField] private PlayerInformationFreeMode _player;
      [SerializeField] private DisplayerSelectedPlayerFreeMode _displayerSelectedPlayer;
      [SerializeField] private Text _text;
      [SerializeField] private Image _iconOfRang;
      [SerializeField] private Sprite[] _backGrounds;
      [SerializeField] private Image _currentIcon;
      [SerializeField] private Image _iconOfCharacter;
    public int CurrentCountOfMoneyForBuying { get => _currentCountOfMoneyForBuying; set => _currentCountOfMoneyForBuying = value; }
    public DisplayerSelectedPlayerFreeMode DisplayerSelectedPlayer { get => _displayerSelectedPlayer; set => _displayerSelectedPlayer = value; }
    public GetterCardFreeMode GetterCard { get; set; }
    public PlayerInformationFreeMode Player { get => _player; set => _player = value; }
    public Image IconOfRang { get => _iconOfRang; set => _iconOfRang = value; }
    [SerializeField] private PlayerAudioSourse _audioSourse;
    private void Start() {
  Player player = Player.GetComponent<Player>();
  _iconOfCharacter.sprite = player.BarIcon;
  _currentIcon.sprite = _backGrounds[player.LevelOfPlayer];
    for (int i = 0; i < Player.LevelOfPlayer +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[Player.LevelOfPlayer];

        }
 // _currentCountOfMoneyForBuying = Player.CountOfMoneyForBuying;
  //SetText(CurrentCountOfMoneyForBuying);
}
public void SetText(int money)
{
  
  _text.text = money.ToString();
}
    public void OnClick()
    {
      
      if(_displayerSelectedPlayer.CameraFreeMode.Camera.orthographicSize < 7 && DisplayerSelectedPlayer.GetterGem.CountOfGem >= _currentCountOfMoneyForBuying && _displayerSelectedPlayer.HavePlayer == false)
      {
        DisplayerSelectedPlayer.Display(Player);
        DisplayerSelectedPlayer.LastPlayerIcon = this;
        DisplayerSelectedPlayer.GetterGem.Buy(_currentCountOfMoneyForBuying);
        Destroy();
      }
       else if(_displayerSelectedPlayer.CameraFreeMode.Camera.orthographicSize >= 7|| DisplayerSelectedPlayer.GetterGem.CountOfGem < _currentCountOfMoneyForBuying)
        {
          PlayerAudioSourse audioSourse = Instantiate(_audioSourse,new Vector3(0,0,0),Quaternion.identity);
          audioSourse.AudioSource.clip = GetterCard.AudioClip;
          audioSourse.AudioSource.Play();
        }
    }
    private void Destroy()
    {
      GetterCard.OnDestroy?.Invoke(DisplayerSelectedPlayer.Background.CountOfCards);
     // GetterCard.CurrentCards.Remove(Player);
      Destroy(gameObject);
    }
}
