using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))] 
public class PlayerInput : MonoBehaviour
{
    private const string OnGround = "OnGround";
    [SerializeField] private Animator _animator;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _animator.SetBool(OnGround, _playerController.OnGround);

        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerController.OnGround)
        {
            _playerController.Jump();
        }
    }
}
