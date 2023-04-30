using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private AudioSource _jumpSound;

    private bool _onGround;
    private float _checkGroundRadius = 0.5f;

    private Vector3 _targetPosition;

    public bool OnGround => _onGround;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        _onGround = CheckingGround();

        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        _jumpSound.Play();
    }

    public bool CheckingGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkGroundRadius, _ground);
    }
}
