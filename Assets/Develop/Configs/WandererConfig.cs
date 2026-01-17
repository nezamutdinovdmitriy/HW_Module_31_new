using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/WandererConfig", fileName = "WandererConfig")]
public class WandererConfig : ScriptableObject
{
    [field: SerializeField] public Wanderer Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 9;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 900f;
    [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
    [field: SerializeField] public float Damage { get; private set; } = 50f;
}
