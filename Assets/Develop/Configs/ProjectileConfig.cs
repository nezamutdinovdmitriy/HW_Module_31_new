using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/Weapon/ProjectileConfig", fileName = "ProjectileConfig")]
public class ProjectileConfig : ScriptableObject
{
    [field: SerializeField] public Projectile Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float MaxDistance { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
}
