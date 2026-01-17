using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllersUpdateService _controllersUpdateService;

    private CharactersFactory _characterFactory;
    private ControllersFactory _controllersFactory;

    private EnemiesSpawner _enemiesSpawner;
    private WandererConfig _wandererConfig;


    private void Awake()
    {
        _controllersUpdateService = new();
        _characterFactory = new();
        _controllersFactory = new();

        MainHeroConfig mainHeroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        _wandererConfig = Resources.Load<WandererConfig>("Configs/WandererConfig");

        LevelConfig levelConfig = Resources.Load<LevelConfig>("Configs/Level/LevelConfig");

        MainHeroFactory mainHeroFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);
        EnemiesFactory enemiesFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);

        _enemiesSpawner = new(enemiesFactory, levelConfig.EnemySpawnPoints, 5f);

        mainHeroFactory.Create(mainHeroConfig, levelConfig.PlayerSpawnPoint);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);

        _enemiesSpawner.Spawn(_wandererConfig);
    }
}
