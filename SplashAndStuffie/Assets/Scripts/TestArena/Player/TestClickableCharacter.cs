using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TestClickableCharacter : MonoBehaviour
{
    private Player _currentPlayer;

    public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
    public TestChangerPlayer Changer { get => _changer; set => _changer = value; }

    private TestChangerPlayer _changer;
    public event UnityAction OnClick;
    private void Start() {
        //FindChanger();
        CurrentPlayer.IPlayerAttackable.OnAttack += ShowText;
    }
    private void ShowText()
    {
        
    }
    public void FindChanger() => Changer = FindObjectOfType<TestChangerPlayer>();

    public void Click()
   {
       if(Changer.IsStopped == false)
       {

       Debug.Log("CAN LIVe!!!" + _currentPlayer.Name);
       TestSkillCreater skillCreater = FindObjectOfType<TestSkillCreater>();
              TestAbilityCreater abilityCreater = FindObjectOfType<TestAbilityCreater>();
              foreach (var item in skillCreater.CurrentSkills)
              {
               skillCreater.SetActiveBoard(item,0,false);
              }
       foreach (var item in abilityCreater.CurrentBoards)
       {
           abilityCreater.SetActiveBoard(item,0,false);
       }
          PlayerInterfaceSkill skill = skillCreater.CurrentSkills.Find(e=> e.Player.Name == _currentPlayer.Name);
          BoardOfReloadingAbility board = abilityCreater.CurrentBoards.Find(e=> e.Player.Name == _currentPlayer.Name);
     abilityCreater.SetActiveBoard(board,1,true);
     skillCreater.SetActiveBoard(skill,1,true);
       Player[] players = FindObjectsOfType<Player>();
       Changer.ChangeCurrentPlayer(CurrentPlayer);
       _currentPlayer.Ability.IsStoppeUsingAbility = false;
       _currentPlayer.GetComponent<Collider2D>().isTrigger = false;
       foreach (var player in players)
       {
           if(player.Name != CurrentPlayer.Name)
           {
               player.Ability.IsStoppeUsingAbility = true;
           player.Rigidbody2D.velocity = Vector2.zero;
      if (player.IPlayerMovement is PlayerDd2Movement)
       {
           player.IPlayerMovement.IsAttacking = true;
       }
       player.GetComponent<Collider2D>().isTrigger = true;
        if (player is Dd1)
       {
           player.GetComponent<Test>().IsStopped = true;
       }
      player.IPlayerMovement.AbleToMove = true;
      player.IPlayerAttackable.IsStopped = true;
           }
       }
       _currentPlayer.IPlayerMovement.AbleToMove = false;
       if (_currentPlayer.IPlayerMovement is PlayerDd2Movement)
       {
           _currentPlayer.IPlayerMovement.IsAttacking = false;
       }
       if (_currentPlayer is Dd1)
       {
           _currentPlayer.GetComponent<Test>().IsStopped = false;
       }
       _currentPlayer.IPlayerAttackable.IsStopped = false;
       Changer.IsStopped = true;
       }
       OnClick?.Invoke();

   }
}
