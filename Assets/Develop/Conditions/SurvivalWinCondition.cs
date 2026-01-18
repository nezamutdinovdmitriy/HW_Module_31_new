using UnityEngine;

public class SurvivalWinCondition : GameCondition
{
    private float _timeRemaining;

    public SurvivalWinCondition(float timeRemaining)
    {
        _timeRemaining = timeRemaining;
    }

    public override bool IsMet()
    {
        _timeRemaining -= Time.deltaTime;
        return _timeRemaining <= 0;
    }
}
