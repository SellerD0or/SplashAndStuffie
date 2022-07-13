using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class OnlineTestPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PhotonView _view;
    private void Start() {
        _view = GetComponent<PhotonView>();
    }
    private void Update() {
        if (_view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * _speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
        }
    }
}
