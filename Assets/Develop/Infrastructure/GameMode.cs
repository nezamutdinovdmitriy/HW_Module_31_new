using System;

public class GameMode
{
    public event Action Win;
    public event Action Defeat;

    private LevelConfig _levelConfig;
    private EnemiesSpawner _enemySpawner;

    private bool _isRunning;

    public GameMode(LevelConfig levelConfig, EnemiesSpawner enemySpawner)
    {
        _levelConfig = levelConfig;
        _enemySpawner = enemySpawner;
    }

    public void Start()
    {
        switch (_levelConfig.WinCondition)
        {
            case WinCondition.Survival:
                break;
            case WinCondition.Elimination:
                break;
        }

        switch (_levelConfig.LoseCondition)
        {
            case LoseCondition.PlayerDeath:
                break;
            case LoseCondition.ArenaOverflow:
                break;
        }

        _isRunning = true;
    }

    public void Update(float deltaTime)
    {
        _enemySpawner.Spawn(_levelConfig.EnemyConfig);
    }

    private void ProcessWin()
    {
        ProcessEndGame();
        Win?.Invoke();
    }

    private void ProcessDefeat()
    {
        ProcessEndGame();
        Defeat?.Invoke();
    }

    private void ProcessEndGame()
    {
        _isRunning = false;

        foreach (Wanderer wanderer in _enemySpawner.SpawnedEntities)
            wanderer.Destroy();
    }
}
