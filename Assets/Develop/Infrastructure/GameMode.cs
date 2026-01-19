using System;

public class GameMode
{
    public event Action Win;
    public event Action Defeat;

    private GameCondition _winCondition;
    private GameCondition _defeatCondition;

    private LevelConfig _levelConfig;
    private EnemiesSpawner _enemySpawner;

    private bool _isRunning;

    public GameMode(LevelConfig levelConfig, EnemiesSpawner enemySpawner, GameCondition winCondition, GameCondition defeatCondition)
    {
        _levelConfig = levelConfig;
        _enemySpawner = enemySpawner;
        _winCondition = winCondition;
        _defeatCondition = defeatCondition;
    }

    public void Start() => _isRunning = true;

    public void Update(float deltaTime)
    {
        if (_isRunning == false)
            return;

        if (_winCondition.IsMet())
        {
            ProcessWin();
            return;
        }
        else if(_defeatCondition.IsMet())
        {
            ProcessDefeat();
            return;
        }

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
        {
            if(wanderer != null)
                wanderer.Destroy();
        }    
    }
}
