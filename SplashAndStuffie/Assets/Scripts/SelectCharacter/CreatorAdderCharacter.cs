using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatorAdderCharacter : MonoBehaviour
{
    private List<AdderCharacter> _adderCharacters = new List<AdderCharacter>();
        public AdderCharacter CurrentAdderCharacter {get;set;}
    public List<AdderCharacter> AdderCharacters { get => _adderCharacters; set => _adderCharacters = value; }
    public int CountOfAdderCharacters { get => _countOfAdderCharacters; set => _countOfAdderCharacters = value; }

    [SerializeField] private  AdderCharacter _adderCharacter;
     [SerializeField] private Transform _adderCharacterPosition;
     private int _countOfAdderCharacters = 3;
     [SerializeField] private SelectablePlayer[] _selectablePlayer;
      private void Start() {
        
       
      }
      public void Find()
      {
            _selectablePlayer = FindObjectsOfType<SelectablePlayer>();
            for (int i = 0; i < CountOfAdderCharacters; i++)
       {
        AdderCharacter adderCharacter =   Instantiate(_adderCharacter,transform.position,Quaternion.identity);
       adderCharacter.transform.SetParent(_adderCharacterPosition,false);
       adderCharacter.OnAdd += SetAdderCharacter;
       }
      }

         public void SetAdderCharacter()
    {
          foreach (var item in _selectablePlayer)
     {
         Debug.Log("xoocl");
         item.AdderCharacter = CurrentAdderCharacter;
     }
     AdderCharacters.Add(CurrentAdderCharacter);
    }
      
}
