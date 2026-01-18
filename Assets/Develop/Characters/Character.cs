using UnityEngine;

public class Character : MonoDestroyable, IDirectionMovable, IDirectionRotatable, IHealth, IDamageable, IShootable
{
    [SerializeField] private Transform _followCameraTarget;
    [SerializeField] private Transform _firePoint;

    private float _maxHealth;
    private float _currentHealth;

    private RigidbodyDirectionalMover _mover;
    private RigidbodyDirectionalRotator _rotator;
    private Shooter _shooter;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Vector3 Position => transform.position;
    public Vector3 ForwardDirection => transform.forward;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Transform CameraTarget => _followCameraTarget;
    public Transform FirePoint => _firePoint;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public void Initialize(RigidbodyDirectionalMover mover, RigidbodyDirectionalRotator rotator, float maxHealth, Shooter shooter)
    {
        _mover = mover;
        _rotator = rotator;
        _shooter = shooter;

        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            Destroy();

        _rotator?.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _mover?.Update(Time.fixedDeltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void TakeDamage(float damage) => _currentHealth -= damage;

    public void Shoot() => _shooter.Shoot(_firePoint);
}
