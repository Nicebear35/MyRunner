using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Score++");
            enemy.gameObject.SetActive(false);
            _player.EncreaseScore();
        }
    }
}
