using UnityEngine;

public class EnemiesFactory
{
    private readonly ControllersUpdateService _controllersUpdateService;
    private readonly CharactersFactory _charactersFactory;
    private readonly ControllersFactory _controllersFactory;

    public EnemiesFactory(ControllersUpdateService controllersUpdateService, CharactersFactory charactersFactory, ControllersFactory controllersFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _charactersFactory = charactersFactory;
        _controllersFactory = controllersFactory;
    }

    public Wanderer CreateWanderer(WandererConfig config, Vector3 spawnPosition)
    {
        Wanderer instance = _charactersFactory.CreateRigidbodyWanderer(
            config.Prefab,
            spawnPosition,
            config.MoveSpeed,
            config.RotationSpeed,
            config.MaxHealth,
            config.Damage);

        Controller controller = _controllersFactory.CreateEnemyRandomPassiveWandererController(instance, instance, 1f, 3f);

        controller.Enable();

        _controllersUpdateService.Add(controller);

        return instance;
    }
}
