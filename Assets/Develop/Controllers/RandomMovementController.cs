using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementController : Controller
{
    private readonly IDirectionMovable _movable;

    private readonly float _minTimeToChangeDirection;
    private readonly float _maxTimeToChangeDirection;

    private float _timeToChangeDirection;
    
    private float _timer;

    private Vector3 _targetDirection;

    public RandomMovementController(IDirectionMovable movable, float minTimeToChangeDirection, float maxTimeToChangeDirection)
    {
        _movable = movable;
        _minTimeToChangeDirection = minTimeToChangeDirection;
        _maxTimeToChangeDirection = maxTimeToChangeDirection;

        _targetDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        _movable.SetMoveDirection(_targetDirection);

        SetRandomTimeToChange();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _timer += deltaTime;

        if (_timer >= _timeToChangeDirection)
        {
            _targetDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            SetRandomTimeToChange();

            _timer = 0;
        }

        _movable.SetMoveDirection(_targetDirection);
    }

    private void SetRandomTimeToChange()
    {
        _timeToChangeDirection = Random.Range(_minTimeToChangeDirection, _maxTimeToChangeDirection);
    }
}
