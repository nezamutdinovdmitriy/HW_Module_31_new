using System;

public class ConditionsFactory
{
    private Character _mainHero;
    private EnemiesSpawner _enemiesSpawner;

    public ConditionsFactory(Character mainHero, EnemiesSpawner enemiesSpawner)
    {
        _mainHero = mainHero;
        _enemiesSpawner = enemiesSpawner;
    }

    public GameCondition CreateWinCondition(WinConditionType condition)
    {
        switch (condition)
        {
            case WinConditionType.Survival:
                return new SurvivalWinCondition(30f);

            case WinConditionType.Elimination:
                return new EliminationWinCondition(_enemiesSpawner, 3);

            default:
                throw new ArgumentOutOfRangeException(condition.ToString());
        }
    }

    public GameCondition CreateLoseCondition(LoseConditionType condition)
    {
        switch (condition)
        {
            case LoseConditionType.PlayerDeath:
                return new PlayerDeathLoseCondition(_mainHero);

            case LoseConditionType.ArenaOverflow:
                return new ArenaOverflowLoseCondition(_enemiesSpawner, 5);

            default:
                throw new ArgumentOutOfRangeException(condition.ToString());
        }
    }
}
