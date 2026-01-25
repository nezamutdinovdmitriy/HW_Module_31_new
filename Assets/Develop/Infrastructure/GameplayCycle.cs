using System;
using UnityEngine;

public class GameplayCycle : IDisposable
{
    private GameMode _gameMode;

    private GameCondition _winCondition;
    private GameCondition _defeatCondition;

    public GameplayCycle(GameMode gameMode)
    {
        _gameMode = gameMode;
    }

    public void Dispose()
    {
        _winCondition?.Dispose();
        _defeatCondition?.Dispose();

        OnGameModeEnded();
    }

    public void Launch()
    {
        _winCondition?.Dispose();
        _defeatCondition?.Dispose();

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
}
