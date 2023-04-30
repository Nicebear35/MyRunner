using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private AudioSource _damageSound;

    private Rigidbody2D _rigidbody2D;
    private float _currentHealth;
    private float _damageUpForce = 200f;
    private int _score = 0;

    public event Action Damaged;
    public event Action Died;
    public event Action ScoreEncreased;

    public int Score => _score;
    public bool IsAlive => _currentHealth > 0;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _score = 0;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _damageSound.Play();
        Damaged?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void EncreaseScore()
    {
        _score++;
        ScoreEncreased?.Invoke();
        
    }
}
