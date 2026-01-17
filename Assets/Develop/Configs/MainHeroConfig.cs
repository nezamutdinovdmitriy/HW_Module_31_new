using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/MainHeroConfig", fileName = "MainHeroConfig")]
public class MainHeroConfig : ScriptableObject
{
    [field: SerializeField] public Character Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 9;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 900f;
    [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
    [field: SerializeField] public ProjectileConfig ProjectilesConfig { get; private set; }
}