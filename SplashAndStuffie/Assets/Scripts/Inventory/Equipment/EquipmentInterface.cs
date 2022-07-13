using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentInterface : MonoBehaviour
{
    [SerializeField] private EquipmentOfCharacter _equipmentOfCharacter;
    [SerializeField] private Transform _equipmentsOfCharacters;
   [SerializeField] private SlotOfCharacter _slotOfCharacter;
    [SerializeField] private Image _iconOfAbility;
    [SerializeField] private Image _iconOfSkill;
    public SlotOfCharacter SlotOfCharacter { get => _slotOfCharacter; set => _slotOfCharacter = value; }
    public Transform EquipmentsOfCharacters { get => _equipmentsOfCharacters; set => _equipmentsOfCharacters = value; }
    public EquipmentOfCharacter EquipmentOfCharacter { get => _equipmentOfCharacter; set => _equipmentOfCharacter = value; }

    public void ChangeIcon(Player player)
    {
        _iconOfAbility.sprite = player.SemitransparentIconAbility;
        _iconOfSkill.sprite = player.SemitransparentIconSkill;
    }
}
