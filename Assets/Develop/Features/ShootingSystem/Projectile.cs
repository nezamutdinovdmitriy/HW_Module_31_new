using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileConfig _config;

    private Vector3 _startPosition;
    private float _sqrMaxDistance;

    private void Start()
    {
        _startPosition = transform.position;
        _sqrMaxDistance = _config.MaxDistance * _config.MaxDistance;
    }

    private void Update()
    {
        Move();
        CheckDistance();
    }

    private void Move() => transform.Translate(Vector3.forward * _config.Speed * Time.deltaTime);

    private void CheckDistance()
    {
        float sqrDistanceTravelled = (transform.position - _startPosition).sqrMagnitude;

        if (sqrDistanceTravelled > _sqrMaxDistance)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_config.Damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
