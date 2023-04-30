using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float _spawnCooldown;

    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_enemyPrefabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnCooldown)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0f;

                SetEnemy(enemy);
            }
        }
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        enemy.transform.position = transform.position;
    }
}
