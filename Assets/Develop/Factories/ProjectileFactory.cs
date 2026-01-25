using UnityEngine;

public class ProjectileFactory
{
    private ProjectileConfig _config;

    public ProjectileFactory(ProjectileConfig config)
    {
        _config = config;
    }

    public Projectile CreateStandartProjectile(Transform transform)
    {
        Projectile instance = Object.Instantiate(_config.Prefab, transform.position, transform.rotation, null);
        instance.Initialize(_config);

        return instance;
    }
}
