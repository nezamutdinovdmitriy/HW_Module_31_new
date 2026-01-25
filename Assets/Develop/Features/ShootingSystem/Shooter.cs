using UnityEngine;

public class Shooter
{
    private readonly ProjectileFactory _projectileFactory;

    public Shooter(ProjectileFactory projectileFactory)
    {
        _projectileFactory = projectileFactory;
    }

    public void Shoot(Transform firePoint) => _projectileFactory.CreateStandartProjectile(firePoint);
}
