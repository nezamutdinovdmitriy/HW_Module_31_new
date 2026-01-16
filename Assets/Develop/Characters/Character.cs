using UnityEngine;

public class Character : MonoBehaviour, IDirectionMovable, IDirectionRotatable
{
    [SerializeField] private Transform _followCameraTarget;

    private RigidbodyDirectionalMover _mover;
    private RigidbodyDirectionalRotator _rotator;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Vector3 Position => transform.position;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Transform CameraTarget => _followCameraTarget;

    public void Initialize(RigidbodyDirectionalMover mover, RigidbodyDirectionalRotator rotator)
    {
        _mover = mover;
        _rotator = rotator;
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _mover.Update(Time.fixedTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
}
