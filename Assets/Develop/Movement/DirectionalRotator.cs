using UnityEngine;

public abstract class DirectionalRotator
{
    private readonly float _rotationSpeed;

    private Vector3 _currentDirection;

    public DirectionalRotator(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    public abstract Quaternion CurrentRotation { get; }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        ApplyRotation(Quaternion.RotateTowards(CurrentRotation, targetRotation, step));
    }

    protected abstract void ApplyRotation(Quaternion rotation);
}
