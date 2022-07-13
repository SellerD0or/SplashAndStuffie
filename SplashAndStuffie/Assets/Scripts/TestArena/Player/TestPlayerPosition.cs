using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestPlayerPosition : MonoBehaviour
{
  [SerializeField] private Player _player;
  private Player _currentPlayer;

    public Player Player { get => _player; set => _player = value; }
    private TestAbilityCreater _abilityCreater;
    private TestSkillCreater _skillCreater;
   private  TestClickableCharacter _testClickableCharacter;
   [SerializeField] private TestPlayerHealthOutPut _playerHealthOutPut;
    private void Awake() 
  {
    _skillCreater = FindObjectOfType<TestSkillCreater>();
    _abilityCreater = FindObjectOfType<TestAbilityCreater>();
      Create();
      
  }
  public void Create()
  {
      Player player = Instantiate(Player,transform.position,Quaternion.identity);
     StopPlayer(player);
    TestPlayerHealthOutPut healthOutPut =  Instantiate(_playerHealthOutPut,transform.position,Quaternion.identity);
    healthOutPut.gameObject.transform.SetParent(player.transform,false);
    healthOutPut.CanvasGroup.alpha = 0;
    healthOutPut.CanvasGroup.blocksRaycasts = false;
    healthOutPut.Player = player;
      _currentPlayer = player;
      _abilityCreater.Create(player);
      _skillCreater.Create(player);
      EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
      triggerEvent.AddListener((eventData) => OnClick());
      player.gameObject.AddComponent<EventTrigger>();
      player.gameObject.AddComponent<TestClickableCharacter>();
      _testClickableCharacter = player.GetComponent<TestClickableCharacter>();
      _testClickableCharacter.FindChanger();
      TestChangerPlayer testChangerPlayer = FindObjectOfType<TestChangerPlayer>();
      testChangerPlayer.PlayerPositions.Add(this);
      testChangerPlayer.HealthOutPuts.Add(healthOutPut);
      _testClickableCharacter.Changer.Players.Add(player);
      EventTrigger eventTrigger = player.GetComponent<EventTrigger>();
      EventTrigger.Entry entry = new EventTrigger.Entry() {callback = triggerEvent, eventID  = EventTriggerType.PointerClick};
      eventTrigger.triggers.Add(entry);

  }
  public void StopPlayer(Player player)
  {
     player.Rigidbody2D.velocity = Vector2.zero;
      if (Player.IPlayerMovement is PlayerDd2Movement)
       {
           Player.IPlayerMovement.IsAttacking = true;
       }
        if (Player is Dd1)
       {
           Player.GetComponent<Test>().IsStopped = true;
       }
      player.IPlayerMovement.AbleToMove = true;
      player.IPlayerAttackable.IsStopped = true;
  }
  public void OnClick()
  {
    Debug.Log("CLICK!!!");
       //  = _currentPlayer.GetComponent<TestClickableCharacter>();
        _testClickableCharacter.CurrentPlayer = _currentPlayer;
        _testClickableCharacter.Click();
  }
}
