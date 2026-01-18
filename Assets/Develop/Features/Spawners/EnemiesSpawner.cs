using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner
{
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

            SpawnedEntities.Add(instance);
        }
    }
}
