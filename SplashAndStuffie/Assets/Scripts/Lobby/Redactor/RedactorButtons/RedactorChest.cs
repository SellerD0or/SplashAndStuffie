using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedactorChest : RedactorButton
{
    [SerializeField] private Animator _panel;
    [SerializeField] private Animator _animator;

    private bool _isMoving;
    [SerializeField] private InventoryBuildingButton _inventoryBuildingButton;
    [SerializeField] private InventoryOfBuildings _inventoryOfBuildings;
    [SerializeField] private Transform _spawnPosition;
    private InventoryBuildingButton _lastInventoryBuildingButton;
    [SerializeField] private ChangerBuilding _changerBuilding;

    public bool IsMoving { get => _isMoving; set => _isMoving = value; }

    private void Awake() {
        _inventoryOfBuildings.OnRemove += OnRemove;
        _inventoryOfBuildings.OnAdd += OnAdd;
    }
    public void OnAdd()
    {
        Debug.Log("ADD");
        InventoryBuildingButton inventoryBuildingButton = Instantiate(_inventoryBuildingButton, transform.position, Quaternion.identity);
        inventoryBuildingButton.transform.SetParent(_spawnPosition);
        inventoryBuildingButton.transform.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        inventoryBuildingButton.transform.localScale = new Vector3(1,1,1);
        inventoryBuildingButton.ChangeIcon(_inventoryOfBuildings.LastBuilding,_changerBuilding);
        _lastInventoryBuildingButton = inventoryBuildingButton;
    }
    public void OnRemove()
    {
        Debug.Log("REMOVE");
       if(_lastInventoryBuildingButton != null)
        Destroy(_lastInventoryBuildingButton.gameObject);
    }
    public override void ChangeStateOfRedactorButton()
    {
        IsMoving =! IsMoving;
        _panel.SetBool("IsMoving", IsMoving);
        // _panel.gameObject .SetActive(_isMoving);
        _animator.SetBool("IsMoving",!IsMoving);
        
       // _panel .SetActive(isActive);
       // _animator.SetBool("IsMoving",true);
    }

    public override void Close()
    {
        //_panel .SetActive(false);
        _animator.SetBool("IsMoving",true);
    }

    public override void Open()
    {
     //   _panel .SetActive(true);
     _animator.SetBool("IsMoving",false);
    }
}
