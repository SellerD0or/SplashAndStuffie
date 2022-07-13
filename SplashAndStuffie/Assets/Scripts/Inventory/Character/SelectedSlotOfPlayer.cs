using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectedSlotOfPlayer : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private SlotOfCharacter _slotOfCharacter;
    private Player _lastPlayer;
    private Equipment _equipment;
    private InventoryBoard _board;
    public Player LastPlayer { get => _lastPlayer; set => _lastPlayer = value; }
    public InventorySelectedPlayer InventorySelectedPlayer { get => _inventorySelectedPlayer; set => _inventorySelectedPlayer = value; }

    private InventorySelectedPlayer _inventorySelectedPlayer;
    private void Start() {
        _board = FindObjectOfType<InventoryBoard>();
        _board.SelectedSlotOfPlayers.Add(this);
        _equipment = FindObjectOfType<Equipment>();
        _slotOfCharacter.OnClick += StartToPlayPlayerAnimation;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(_board.CurrentSelectedSlotOfPlayer != this && _board.IsClicked == false && _slotOfCharacter.IsOpen)
        {
       List<SelectedSlotOfPlayer> selectedSlotOfPlayers = _board.SelectedSlotOfPlayers.FindAll(e=> e.LastPlayer != null);
       foreach (var item in selectedSlotOfPlayers)
       {
           Destroy(item.LastPlayer.gameObject);
       }
        LastPlayer = Instantiate(_slotOfCharacter.Player,_equipment.CharacterPosition.position,Quaternion.identity);
        if(LastPlayer.GetComponent<InventorySelectedPlayer>() == false)
        {
        LastPlayer.gameObject.AddComponent<InventorySelectedPlayer>();
        }
        InventorySelectedPlayer = LastPlayer.GetComponent<InventorySelectedPlayer>();
        LastPlayer.IPlayerAttackable.IsStopped = true;
        LastPlayer.IPlayerMovement.AbleToMove = true;
        LastPlayer.Ability.IsStoppeUsingAbility = true;
        if (LastPlayer is BotZ)
        {
            LastPlayer.transform.position = new Vector3(_equipment.CharacterPosition.position.x,1.97f,0);
        }
        else if(LastPlayer is Rong)
        {
         LastPlayer.transform.position = new Vector3(_equipment.CharacterPosition.position.x,1.21f,0);
        }
        else if(LastPlayer is Axel)
        {
         LastPlayer.transform.position = new Vector3(_equipment.CharacterPosition.position.x,-4.983497f,0);
        }
        else if(LastPlayer is Dd2)
        {
            LastPlayer.transform.localScale = new Vector3(0.93312f, 0.93312f, 0.93312f);
        }
        else if(LastPlayer is Aki)
        {
            LastPlayer.transform.position = new Vector3(_equipment.CharacterPosition.position.x, -1.64f, 0);
        }
        _board.CurrentSelectedSlotOfPlayer = this;
        }
    }
    private void StartToPlayPlayerAnimation()
    {
        if (LastPlayer is Aki || LastPlayer is MummyHat || LastPlayer is Axel)
        {
          InventorySelectedPlayer.NameOfAnimation = "view";
          InventorySelectedPlayer.UnityArmatureComponent.sortingOrder = -9;
        }
        if (LastPlayer is MummyHat || LastPlayer is Axel)
        {
            if(LastPlayer.GetComponent<Animator>() == false)
            {
            LastPlayer.gameObject.AddComponent<Animator>();
            }
            InventorySelectedPlayer.Animator = LastPlayer.GetComponent<Animator>();
            if(LastPlayer is MummyHat)
            {
            InventorySelectedPlayer.Animator.runtimeAnimatorController = _equipment.MummtHatRuntimeAnimatorController;
            }
            else if(LastPlayer is Axel)
            {
                InventorySelectedPlayer.Animator.runtimeAnimatorController = _equipment.AxelRuntimeAnimatorController;
            }
      _inventorySelectedPlayer.Animator.SetTrigger("shake");
        }
                LastPlayer.IPlayerAnimator.EnemyAnimator= null;
        InventorySelectedPlayer.PlayAnimation();

    }

}
