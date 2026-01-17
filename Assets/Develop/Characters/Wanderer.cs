using UnityEngine;

public class Wanderer : MonoBehaviour, IDirectionMovable, IDirectionRotatable, IHealth, IDamageable
{
    private float _maxHealth;
    private float _currentHealth;
    private float _touchDamage;

    private RigidbodyDirectionalMover _mover;
    private RigidbodyDirectionalRotator _rotator;

    public Vector3 Position => transform.position;

    public Vector3 ForwardDirection => transform.forward;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public float MaxHealth => _maxHealth;

    public float CurrentHealth => _currentHealth;

    public bool IsDead => _currentHealth <= 0;

    public void Initialize(RigidbodyDirectionalMover mover, RigidbodyDirectionalRotator rotator, float maxHealth, float touchDamage)
    {
        _mover = mover;
        _rotator = rotator;

        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;

        _touchDamage = touchDamage;
    }

    private void Update()
    {
        if(IsDead)
            Destroy(gameObject);

        _rotator?.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _mover?.Update(Time.fixedDeltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void TakeDamage(float damage) => _currentHealth -= damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Character character))
            character.TakeDamage(_touchDamage);
    }
}
