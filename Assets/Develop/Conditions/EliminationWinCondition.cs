
using System;
using UnityEngine;

public class EliminationWinCondition : GameCondition, IDisposable
{
    private readonly EnemiesSpawner _enemiesSpawner;
    private readonly int _targetKills;

    private int _currentKills;

    public EliminationWinCondition(EnemiesSpawner enemiesSpawner, int targetKills)
    {
        _enemiesSpawner = enemiesSpawner;
        _targetKills = targetKills;

        _enemiesSpawner.EnemyKilled += OnEnemyKilled;
    }

    public void OnEnemyKilled()
    {
        _currentKills++;

        Debug.Log($"Kills: {_currentKills}/{_targetKills}");
    }

    public override bool IsMet()
    {
        return _currentKills >= _targetKills;
    }

    public override void Dispose()
    {
        _enemiesSpawner.EnemyKilled -= OnEnemyKilled;
    }
}
