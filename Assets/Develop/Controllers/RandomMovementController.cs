using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementController : Controller
{
    private const float OffsetRaycastPoint = 0.7f;

    private readonly IDirectionMovable _movable;
    private readonly float _detectionDistance;

    private float _timer;

    private Vector3 _currentDirection;

    public RandomMovementController(IDirectionMovable movable, float detectionDistance)
    {
        _movable = movable;
        _detectionDistance = detectionDistance;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _timer -= deltaTime;

        if (_timer < 0)
        {
            _currentDirection = GetRandomDirection();
            _timer = Random.Range(1f, 5f);
        }

        _movable.SetMoveDirection(_currentDirection);
    }

    private bool HasObstacle(Vector3 direction)
    {
        Vector3 rayOrigin = _movable.Position + Vector3.up + (direction * OffsetRaycastPoint);

        return Physics.Raycast(rayOrigin, direction, _detectionDistance);
    }

    private Vector3 GetRandomDirection()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 candidate = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            if(candidate.sqrMagnitude > 0.01f)
            {
                candidate.Normalize();
                
                if(HasObstacle(candidate))
                    return candidate;
            }
        }
        return Vector3.zero;
    }
}
