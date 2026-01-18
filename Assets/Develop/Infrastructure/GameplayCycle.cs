using System;
using UnityEngine;

public class GameplayCycle : IDisposable
{
    private MainHeroFactory _mainHeroFactory;
    private MainHeroConfig _mainHeroConfig;

    private Character _mainHero;

    private LevelConfig _levelConfig;

    private GameMode _gameMode;

    private EnemiesSpawner _enemiesSpawner;

    private GameCondition _winCondition;
    private GameCondition _defeatCondition;

    public GameplayCycle(MainHeroFactory mainHeroFactory, MainHeroConfig mainHeroConfig, LevelConfig levelConfig, EnemiesSpawner enemiesSpawner)
    {
        _mainHeroFactory = mainHeroFactory;
        _mainHeroConfig = mainHeroConfig;
        _levelConfig = levelConfig;
        _enemiesSpawner = enemiesSpawner;
    }

    public void Dispose()
    {
        _winCondition?.Dispose();
        _defeatCondition?.Dispose();

        OnGameModeEnded();
    }

    public void Prepare()
    {
        _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.PlayerSpawnPoint);
    } 

    public void Launch()
    {
        _winCondition?.Dispose();
        _defeatCondition?.Dispose();

        _enemiesSpawner.Reset();

        _winCondition = SetWinCondition(_levelConfig.WinCondition);
        _defeatCondition = SetDefeatCondition(_levelConfig.LoseCondition);

        _gameMode = new GameMode(_levelConfig, _enemiesSpawner, _winCondition, _defeatCondition);

        _gameMode.Win += OnGameModeWin;
        _gameMode.Defeat += OnGameModeDefeat;

        _gameMode.Start();
    }

    public void Update (float deltaTime) => _gameMode?.Update(deltaTime);

    private void OnGameModeDefeat()
    {
        OnGameModeEnded();
        Debug.Log("Defeat!");
    }

    private void OnGameModeWin()
    {
        OnGameModeEnded();
        Debug.Log("Win!");
    }

    private void OnGameModeEnded()
    {
        if(_gameMode != null)
        {
            _gameMode.Win -= OnGameModeWin;
            _gameMode.Defeat -= OnGameModeDefeat;
        }
    }

    private GameCondition SetWinCondition(WinConditionType winCondition)
    {
        switch (winCondition)
        {
            case WinConditionType.Survival:
                return new SurvivalWinCondition(30f);

            case WinConditionType.Elimination:
                return new EliminationWinCondition(_enemiesSpawner, 3);

            default:
                throw new ArgumentOutOfRangeException(_levelConfig.WinCondition.ToString());
        }
    }
    private GameCondition SetDefeatCondition(LoseConditionType defeatCondition)
    {
        switch (defeatCondition)
        {
            case LoseConditionType.PlayerDeath:
                return new PlayerDeathLoseCondition(_mainHero);

            case LoseConditionType.ArenaOverflow:
                return new ArenaOverflowLoseCondition(_enemiesSpawner, 5);

            default:
                throw new ArgumentOutOfRangeException(_levelConfig.WinCondition.ToString());
        }
    }
}
