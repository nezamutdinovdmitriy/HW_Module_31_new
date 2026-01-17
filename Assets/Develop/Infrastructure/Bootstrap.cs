using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Transform _mainHeroSpawnPosition;
    [SerializeField] private Transform _enemySpawnPosition;

    private ControllersUpdateService _controllersUpdateService;

    private CharactersFactory _characterFactory;
    private ControllersFactory _controllersFactory;
    
    private void Awake()
    {
        _controllersUpdateService = new();
        _characterFactory = new();
        _controllersFactory = new();

        MainHeroConfig mainHeroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        WandererConfig wandererConfig = Resources.Load<WandererConfig>("Configs/WandererConfig");

        MainHeroFactory mainHeroFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);
        mainHeroFactory.Create(mainHeroConfig, _mainHeroSpawnPosition.position);

        EnemiesFactory enemiesFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);
        enemiesFactory.CreateWanderer(wandererConfig, _enemySpawnPosition.position);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
    }
}
