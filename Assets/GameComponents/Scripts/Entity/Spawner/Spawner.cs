using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public event UnityAction AllEnemySpawned;
    public event UnityAction<float> EnemyCountChanged;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _attackedTarget;
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            _timeAfterLastSpawn = 0;

            InstantiateEnemy();
            _spawned++;

            EnemyCountChanged?.Invoke(ReturnNormalizedCountOfSpawned());
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.EnemyPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint).GetComponent<Enemy>();

        enemy.Initialize(_attackedTarget);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDied(Entity enemy)
    {
        enemy.Died -= OnEnemyDied;

        _attackedTarget.AddMoney(((Enemy)enemy).Reward);
    }

    public void SetNextWave()
    {
        _currentWaveNumber++;
        SetWave(_currentWaveNumber);

        _spawned = 0;

        EnemyCountChanged?.Invoke(ReturnNormalizedCountOfSpawned());
    }

    private float ReturnNormalizedCountOfSpawned()
    {
        float normalizedSpawnedCount = 0f;

        if (_currentWave != null)
        {
            normalizedSpawnedCount = (float)_spawned / _currentWave.Count;
        }

        return normalizedSpawnedCount;
    }
}

[System.Serializable]

public class Wave
{
    public Enemy EnemyPrefab;
    public float Delay;
    public int Count;
}