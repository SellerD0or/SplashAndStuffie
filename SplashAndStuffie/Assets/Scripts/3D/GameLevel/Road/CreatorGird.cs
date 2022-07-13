using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorGird : MonoBehaviour
{
   private Dictionary<PlayerMovement3DDirection, Vector3> _directions = new Dictionary<PlayerMovement3DDirection, Vector3> 
   {
       {PlayerMovement3DDirection.Left, Vector3.left},
        {PlayerMovement3DDirection.Right, Vector3.right},
         {PlayerMovement3DDirection.Up, Vector3.up},
          {PlayerMovement3DDirection.Down, Vector3.down},

   };
   private Camera _camera;
   private static bool _selectBuilding;

    public static bool SelectBuilding { get => _selectBuilding; set => _selectBuilding = value; }
    public static bool ChangedState { get => _changedState; set => _changedState = value; }
    [SerializeField] private IconOfCreatedPlayer3D _iconOfCreatedPlayer3D;
    private static bool _changedState = true;
        private void Start() {
       _camera  =Camera.main;
   }
   private void Update() {
       if (Input.GetMouseButtonDown(0) && _iconOfCreatedPlayer3D.IsSelectedPlayer)
       {
           RaycastHit  hit;
           Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(ray, out hit))
           {
               if (hit.collider.TryGetComponent<Grid3D>(out Grid3D place))
               {
               //  PlayerMovement3DDirection playerMovement3DDirection =  _directions.(place.Direction);
                 Player player = Instantiate(_iconOfCreatedPlayer3D.SelectedCharacter,place.transform.position, Quaternion.identity);
                 player.gameObject.AddComponent<PlayerMovement3D>();
                 _iconOfCreatedPlayer3D.IsSelectedPlayer = false;
               }
           }
       }
   }
}
