using Cinemachine;
using UnityEngine;

public class MainHeroFactory
{
    private readonly ControllersUpdateService _controllersUpdateService;
    private readonly CharactersFactory _charactersFactory;
    private readonly ControllersFactory _controllersFactory;

    public MainHeroFactory(ControllersUpdateService controllersUpdateService, CharactersFactory charactersFactory, ControllersFactory controllersFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _charactersFactory = charactersFactory;
        _controllersFactory = controllersFactory;
    }

    public Character Create(MainHeroConfig config, Vector3 spawnPosition)
    {
        Character instance = _charactersFactory.CreateRigidbodyCharacter(config.Prefab, spawnPosition, config.MoveSpeed, config.RotationSpeed, config.MaxHealth, config.ProjectilesConfig.Prefab);

        Controller controller = _controllersFactory.CreateMainHeroController(instance);
        controller.Enable();

        _controllersUpdateService.Add(controller);

        CinemachineVirtualCamera followCameraPrefab = Resources.Load<CinemachineVirtualCamera>("Cameras/FollowCamera");
        CinemachineVirtualCamera followCamera = Object.Instantiate(followCameraPrefab);
        followCamera.Follow = instance.CameraTarget;

        return instance;
    }
}
