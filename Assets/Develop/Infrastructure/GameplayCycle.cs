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

    public GameplayCycle(MainHeroFactory mainHeroFactory, MainHeroConfig mainHeroConfig, LevelConfig levelConfig, EnemiesSpawner enemiesSpawner)
    {
        _mainHeroFactory = mainHeroFactory;
        _mainHeroConfig = mainHeroConfig;
        _levelConfig = levelConfig;
        _enemiesSpawner = enemiesSpawner;
    }

    public void Prepare()
    {
        _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.PlayerSpawnPoint);
    } 

    public void Launch()
    {
        _gameMode = new GameMode(_levelConfig, _enemiesSpawner);

        _gameMode.Win += OnGameModeWin;
        _gameMode.Defeat += OnGameModeDefeat;

        _gameMode.Start();
    }

    public void Update (float deltaTime) => _gameMode?.Update(deltaTime);

    private void OnGameModeDefeat()
    {
        OnGameModeEnded();
        Debug.Log("Defeat!");
        Launch();
    }

    private void OnGameModeWin()
    {
        OnGameModeEnded();
        Debug.Log("Win!");
        Launch();
    }

    private void OnGameModeEnded()
    {
        if(_gameMode != null)
        {
            _gameMode.Win -= OnGameModeWin;
            _gameMode.Defeat -= OnGameModeDefeat;
        }
    }

    public void Dispose() => OnGameModeEnded();
}
