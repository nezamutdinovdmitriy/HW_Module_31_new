using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public WinConditionType WinCondition { get; private set; }
    [field: SerializeField] public LoseConditionType LoseCondition { get; private set; }
    [field: SerializeField] public WandererConfig EnemyConfig { get; private set; }
    [field: SerializeField] public List<Vector3> EnemySpawnPoints { get; private set; }
    [field: SerializeField] public Vector3 PlayerSpawnPoint { get; private set; }
}
