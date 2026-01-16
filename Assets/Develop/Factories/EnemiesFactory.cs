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
}
