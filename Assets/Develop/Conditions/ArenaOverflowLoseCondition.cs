public class ArenaOverflowLoseCondition : GameCondition
{
    private readonly EnemiesSpawner _enemiesSpawner;
    private readonly int _maxEnemies;

    public ArenaOverflowLoseCondition(EnemiesSpawner enemiesSpawner, int maxEnemies)
    {
        _enemiesSpawner = enemiesSpawner;
        _maxEnemies = maxEnemies;
    }

    public override bool IsMet()
    {
        _enemiesSpawner.SpawnedEntities.RemoveAll(enemy => enemy == null || enemy.IsDestroyed);
        return _enemiesSpawner.SpawnedEntities.Count >= _maxEnemies;
    }
}
