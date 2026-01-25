using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private ProjectileConfig _config;
    private Vector3 _startPosition;
    private float _sqrMaxDistance;

    public void Initialize(ProjectileConfig config)
    {
        _config = config;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _sqrMaxDistance = _config.MaxDistance * _config.MaxDistance;

        _rigidbody.velocity = transform.forward * _config.Speed;
    }

    private void Update() => CheckDistance();

    private void CheckDistance()
    {
        float sqrDistanceTravelled = (transform.position - _startPosition).sqrMagnitude;

        if (sqrDistanceTravelled > _sqrMaxDistance)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_config.Damage);

        Destroy(gameObject);
    }
}
