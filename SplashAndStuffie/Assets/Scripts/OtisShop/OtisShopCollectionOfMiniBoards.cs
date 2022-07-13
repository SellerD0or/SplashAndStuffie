using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtisShopCollectionOfMiniBoards : MonoBehaviour
{
   [SerializeField] private List<OtisShopBoard> _boards;
   private int _currentBoard;
   private string _nameOfCurrentBoard;
   private void Start() {
       if (PlayerPrefs.HasKey("OtisShop"))
       {
          string name = PlayerPrefs.GetString("OtisShop");
          if (name == "DROP")
          {
              _nameOfCurrentBoard =  PlayerPrefs.GetString("OtisShopBoard");
              if (_nameOfCurrentBoard == "ITEMS")
              {
                 _boards[_currentBoard].gameObject.SetActive(false);
                  _currentBoard = 2;
                  _boards[_currentBoard].gameObject.SetActive(true);
              }
              else  if (_nameOfCurrentBoard == "AKI")
              {
                  _boards[_currentBoard].gameObject.SetActive(false);
                  _currentBoard = 0;
                  _boards[_currentBoard].gameObject.SetActive(true);
              }
                else  if (_nameOfCurrentBoard == "PLAYERS")
              {
                  _boards[_currentBoard].gameObject.SetActive(false);
                  _currentBoard = 1;
                  _boards[_currentBoard].gameObject.SetActive(true);
              }
          }
          
       }
   }
   public void TurnRight()
   {
       if (_currentBoard < _boards.Count - 1)
       {
             _boards[_currentBoard].gameObject.SetActive(false);
           _currentBoard++;
           _boards[_currentBoard].gameObject.SetActive(true);
       }
       else
       {
       _boards[_currentBoard].gameObject.SetActive(false);
           _currentBoard = 0;
           _boards[_currentBoard].gameObject.SetActive(true);
       }
   }
    public void TurnLeft()
   {
       if (_currentBoard > 0)
       {
             _boards[_currentBoard].gameObject.SetActive(false);
           _currentBoard--;
           _boards[_currentBoard].gameObject.SetActive(true);
       }
       else
       {
          _boards[_currentBoard].gameObject.SetActive(false);
           _currentBoard = _boards.Count - 1;
           _boards[_currentBoard].gameObject.SetActive(true);
       }
   }
}
