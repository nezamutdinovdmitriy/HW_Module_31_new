using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllersUpdateService _controllersUpdateService;

    private CharactersFactory _characterFactory;
    private ControllersFactory _controllersFactory;

    private GameplayCycle _gameplayCycle;

    private void Awake()
    {
        _controllersUpdateService = new();
        _characterFactory = new();
        _controllersFactory = new();

        MainHeroConfig mainHeroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        WandererConfig wandererConfig = Resources.Load<WandererConfig>("Configs/WandererConfig");

        LevelConfig levelConfig = Resources.Load<LevelConfig>("Configs/Level/LevelConfig");


        MainHeroFactory mainHeroFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);
        EnemiesFactory enemiesFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);

        EnemiesSpawner enemiesSpawner = new(enemiesFactory, levelConfig.EnemySpawnPoints, 5f);

        _gameplayCycle = new GameplayCycle(mainHeroFactory, mainHeroConfig, levelConfig, enemiesSpawner);

        _gameplayCycle.Prepare();

        _gameplayCycle.Launch();
    }

    private void OnDestroy()
    {
        _gameplayCycle?.Dispose();
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
        _gameplayCycle?.Update(Time.deltaTime);
    }
}
