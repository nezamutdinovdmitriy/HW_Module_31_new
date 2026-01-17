using UnityEngine;

public class Shooter
{
    private readonly Projectile _projectilePrefab;

    public Shooter(Projectile projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
    }

    public void Shoot(Transform firePoint) => Object.Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation, null);
}
