using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkillCreater : MonoBehaviour
{
   private List<PlayerInterfaceSkill> _currentSkills = new List<PlayerInterfaceSkill>();
       [SerializeField] private PlayerInterfaceSkill _skill;
   [SerializeField] private Transform _skillPosition;
    public List<PlayerInterfaceSkill> CurrentSkills { get => _currentSkills; set => _currentSkills = value; }

    public void Create(Player player)
   {
                  PlayerInterfaceSkill skill = Instantiate(_skill,new Vector3(0,0,0),Quaternion.identity);
         skill.GetPlayer(player);
         skill.transform.SetParent(_skillPosition,false);
         skill.CanvasGroup.alpha = 0;
         skill.CanvasGroup.blocksRaycasts = false;
         if (player.Name == "Stuffie")
         {
            skill.IsDd2Skill = true;
         }
         CurrentSkills.Add(skill);

   }
   public void SetActiveBoard(PlayerInterfaceSkill board,float alpha, bool blocksRaycasts)
   {
        board.CanvasGroup.alpha = alpha;
         board.CanvasGroup.blocksRaycasts = blocksRaycasts;
   }
}
