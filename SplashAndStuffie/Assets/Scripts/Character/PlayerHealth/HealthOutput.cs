using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class HealthOutput : MonoBehaviour
{
  private PlayerInterface _playerInterface;
  public event UnityAction OnTakeDamage;
  [SerializeField] private CanvasGroup _interfaceHealth;
   [SerializeField] private CanvasGroup _canvasGroupHealth;
  [SerializeField] private Image _background;
  [SerializeField] private Sprite[] _spritesOfBackground;
 [SerializeField] private int _index;
  [SerializeField] private GameObject _iconPosition;
   [SerializeField] private Player _startedPlayer;
   private Player _player;
   [SerializeField] private Image _healthBar;
    private float _fillValue;
  [SerializeField] private GetterPlayer _playerHealth;
  [SerializeField] private Image _icon;

    public Player StartedPlayer { get => _startedPlayer; set => _startedPlayer = value; }
    public GetterPlayer PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public Image HealthBar { get => _healthBar; set => _healthBar = value; }
    public float FillValue { get => _fillValue; set => _fillValue = value; }
    public int Index { get => _index; set => _index = value; }

    private void Start() {
      _playerInterface = FindObjectOfType<PlayerInterface>();
      UpdateHealth();
      ChangeIcon();
    _playerHealth.OnDestroy += UpdateHealth;
    _playerHealth.OnDestroy += GetPlayer;
     
  }
  public void UpdateHealth()
{
  Debug.Log(StartedPlayer);
   StartedPlayer.PlayerHealth.ApplyDamage += TakeDamage;
}
  public void ChangeIcon()
  {
    Debug.Log("CHANGE PLAYER!!! ");
   Sprite spriteOfBackground = StartedPlayer.LevelOfPlayer >= 2 ? _spritesOfBackground[2] : _spritesOfBackground[StartedPlayer.LevelOfPlayer];
   _background.sprite = spriteOfBackground;
    _icon.sprite = StartedPlayer.Icon;
    
  }
  public void SetCurrentHealth(HealthOutput healthOutput)
  {
    if (healthOutput.Index == 0)
    {
      _playerHealth.HealthsOutputs[1].transform.localPosition = new Vector2(50, -100);
        _playerHealth.HealthsOutputs[2].transform.localPosition = new Vector2(50, -242.25f);
    }
    if (healthOutput.Index == 1)
    {
      _playerHealth.HealthsOutputs[0].transform.localPosition = new Vector2(50, -100);
      _playerHealth.HealthsOutputs[2].transform.localPosition = new Vector2(50, -242.25f);
    }
    if (healthOutput.Index == 2)
    {
      _playerHealth.HealthsOutputs[0].transform.localPosition = new Vector2(50, -100);
        _playerHealth.HealthsOutputs[1].transform.localPosition = new Vector2(50, -242.25f);
    }
    
    /*foreach (var item in PlayerHealth.HealthsOutputs)
    {
      item.transform.localPosition = new Vector2(50, -50 + item.Index * -142.95f);
     if (item.Index == 0)
     {
       item.transform.localPosition = new Vector2(50,-50);
     }
     else if (item.Index == 1)
     {
           item.transform.localPosition = new Vector2(50,-192.95f);
     }
     else if (item.Index == 2)
     {
           item.transform.localPosition = new Vector2(50,-335.9f);
     }
     item._iconPosition.transform.localPosition = new Vector3(-544.4f,298.2f,0);
    item._iconPosition.transform.localScale = new Vector3(0.5389467f,0.5389467f,0);
    }*/
         healthOutput._canvasGroupHealth.alpha = 0;
         _interfaceHealth.alpha = 1;
    transform.localPosition = new Vector2(50,-335.9f);
        Debug.Log(transform.localPosition  + " it's a position of me: " + name);
    _iconPosition.transform.localPosition = new Vector3(-478.1f,192f,0);
    _iconPosition.transform.localScale = new Vector3(0.8990737f,0.8990737f,0);
  }
  public void SetDefaltPosition(HealthOutput healthOutput)
  {
    _iconPosition.transform.localPosition = new Vector3(-544.4f,298.2f,0);
    _iconPosition.transform.localScale = new Vector3(0.5389467f,0.5389467f,0);
     healthOutput._canvasGroupHealth.alpha = 1;
     if(healthOutput._interfaceHealth.alpha == 1)
     {
       healthOutput._interfaceHealth.alpha =0;
     }
   //    healthOutput.transform.localPosition = new Vector2(50, -50 + healthOutput.Index * -142.95f);
  //   healthOutput._iconPosition.transform.localPosition = new Vector3(-544.4f,298.2f,0);
  //  healthOutput._iconPosition.transform.localScale = new Vector3(0.5389467f,0.5389467f,0);

  }
  public void TakeDamage()
  {
//    Debug.LogError("CHANGE HEALTH " + name + " name player: " + StartedPlayer + " AND HIS HEALTH: " + StartedPlayer.PlayerHealth.Health);
//      Debug.LogError("change health bar"); 
       if(StartedPlayer.PlayerHealth.Health < StartedPlayer.PlayerHealth.MaxHealth)
       {
        FillValue = (float)StartedPlayer.PlayerHealth.Health;
        FillValue = FillValue / StartedPlayer.PlayerHealth.MaxHealth;
        HealthBar.fillAmount = FillValue;
       }
       _playerInterface.UpdateText();
       OnTakeDamage?.Invoke();
  }
  private void OnDisable() {
//      _player.PlayerHealth .ApplyDamage -= TakeDamage;
  }
          public void GetPlayer()
    {
       Debug.Log("Cool we rechange character!");
     //   _player = _playerHealth.CreatedPlayer;
       // _startedPlayer = _player;
        ChangeIcon();
      UpdateHealth();
    }
    private void Update() {
//      Debug.LogError(HealthBar.fillAmount + " NAME OF HEALTH OUTPUT IS " + name + " FILL AMOUND == " + FillValue);
    }
}
