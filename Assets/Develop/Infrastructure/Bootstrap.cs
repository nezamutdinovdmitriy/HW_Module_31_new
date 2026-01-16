using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Transform _mainHeroSpawnPosition;

    private ControllersUpdateService _controllersUpdateService;

    private CharactersFactory _characterFactory;
    private ControllersFactory _controllersFactory;
    
    private void Awake()
    {
        _controllersUpdateService = new();
        _characterFactory = new();
        _controllersFactory = new();

        MainHeroConfig mainHeroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");

        MainHeroFactory mainHeroFactory = new(_controllersUpdateService, _characterFactory, _controllersFactory);
        mainHeroFactory.Create(mainHeroConfig, _mainHeroSpawnPosition.position);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
    }
}
