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
    }

    private void OnEnable()
    {
        foreach (var enemy in _livingEnemies)
            enemy.DamageTaking += OnDamageTaking;
    }

    private void OnDisable()
    {
        foreach (var enemy in _livingEnemies)
            enemy.DamageTaking -= OnDamageTaking;
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
            Spawn(transform, new Vector3(i, 0, 0));
    }

    private void Spawn(Transform parent, Vector3 position)
    {
        var spawnedEnemy = Instantiate(_template, parent);
        spawnedEnemy.transform.position = position;
        _livingEnemies.Add(spawnedEnemy);
        spawnedEnemy.DamageTaking += OnDamageTaking;
    }

    private void OnDamageTaking(Enemy enemy)
    {
        _livingEnemies.Remove(enemy);
        enemy.DamageTaking -= OnDamageTaking;
        Destroy(enemy.gameObject);

        if (_livingEnemies.Count == 0)
            _diedAllEnemies?.Invoke();
    }
}
