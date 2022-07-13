using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbilityCreater : MonoBehaviour
{
     private List<BoardOfReloadingAbility> _currentBoards = new List<BoardOfReloadingAbility>();
      [SerializeField] private BoardOfReloadingAbility _board;
    [SerializeField] private Transform _boardPosition;

    public List<BoardOfReloadingAbility> CurrentBoards { get => _currentBoards; set => _currentBoards = value; }
   public void Create(Player player)
   {
                BoardOfReloadingAbility board = Instantiate(_board, _boardPosition.position, Quaternion.identity);
         board.Player= player;
         board.transform.SetParent(_boardPosition,false);
         board.CanvasGroup.alpha = 0;
         board.CanvasGroup.blocksRaycasts = false;
         CurrentBoards.Add(board);
   }
   public void SetActiveBoard(BoardOfReloadingAbility board,float alpha, bool blocksRaycasts)
   {
        board.CanvasGroup.alpha = alpha;
         board.CanvasGroup.blocksRaycasts = blocksRaycasts;
   }
}
