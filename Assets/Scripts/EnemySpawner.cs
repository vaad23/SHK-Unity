using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private UnityEvent _diedAllEnemies;

    private List<Enemy> _livingEnemies;    

    private void Awake()
    {
        _livingEnemies = new List<Enemy>();

        for (int i = 0; i < 4; i++)
        {
            Spawn(transform, new Vector3(i, 0, 0));
        }
    }

    private void Spawn(Transform parent, Vector3 position)
    {
        var spawnedEnemy = Instantiate(_template, parent);
        spawnedEnemy.transform.position = position;
        _livingEnemies.Add(spawnedEnemy);
        spawnedEnemy.TakedDamageEvent += OnTakedDamage;
    }

    private void OnTakedDamage(Enemy enemy)
    {
        _livingEnemies.Remove(enemy);
        enemy.TakedDamageEvent -= OnTakedDamage;
        Destroy(enemy.gameObject);

        if (_livingEnemies.Count == 0)
            _diedAllEnemies?.Invoke();
    }
}
