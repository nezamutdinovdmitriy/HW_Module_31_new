using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner
{
    public event Action EnemyKilled;

    private readonly EnemiesFactory _enemiesFactory;
    private readonly List<Vector3> _spawnPoints;
    private readonly float _timeToSpawn;

    private float _time;

    public List<Wanderer> SpawnedEntities = new List<Wanderer>();

    public EnemiesSpawner(EnemiesFactory enemiesFactory, List<Vector3> spawnPoints, float timeToSpawn)
    {
        _enemiesFactory = enemiesFactory;
        _spawnPoints = spawnPoints;
        _timeToSpawn = timeToSpawn;
    }

    public void Spawn(WandererConfig config)
    {
        _time += Time.deltaTime;

        if(_time >= _timeToSpawn)
        {
            Wanderer instance = _enemiesFactory.CreateWanderer(config, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);

            _time = 0;

            instance.Destroyed += OnEnemyDestroyed;
            
            SpawnedEntities.Add(instance);
        }
    }

    private void OnEnemyDestroyed(MonoDestroyable entity)
    {
        entity.Destroyed -= OnEnemyDestroyed;

        if (entity is Wanderer wanderer && wanderer.IsDead)
            EnemyKilled?.Invoke();
    }

    public void Reset()
    {
        _time = 0;
        SpawnedEntities.Clear();
        EnemyKilled = null;
    }
}
