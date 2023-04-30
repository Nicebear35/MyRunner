using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<Enemy> _enemyPool = new List<Enemy>();

    protected void Initialize(List<GameObject> prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefabs[Random.Range(0, prefabs.Count)], _container.transform);
            spawned.SetActive(false);

            Enemy enemy = spawned.GetComponent<Enemy>();
            _enemyPool.Add(enemy);
        }
    }

    protected void ShiftElements()
    {
        for (int i = 0; i < _enemyPool.Count - 1; i++)
        {
            Enemy tempEnemy = _enemyPool[i + 1];
            _enemyPool[i + 1] = _enemyPool[i];
            _enemyPool[i] = tempEnemy;
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _enemyPool.FirstOrDefault(x => x.gameObject.activeSelf == false).gameObject;
        ShiftElements();

        return result != null;
    }
}
