using UnityEngine;

public abstract class DirectionalMover
{
    private readonly float _moveSpeed;

    private Vector3 _currentDirection;

    public DirectionalMover(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public Vector3 CurrentVelocity => _currentDirection.normalized * _moveSpeed;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public abstract void Update(float deltaTime);
}
