using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Player _player;

    private float _normalizedHeath => _player.CurrentHealth / _player.MaxHealth;

    private void OnEnable()
    {
        _player.Damaged += ChangeBarValue;
    }

    private void OnDisable()
    {
        _player.Damaged -= ChangeBarValue;
    }

    private void ChangeBarValue()
    {
        _healthBar.fillAmount = _normalizedHeath;
    }
}
