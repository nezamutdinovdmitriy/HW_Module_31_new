public class ControllersFactory
{
    public PlayerDirectionalMovableController CreatePlayerDirectionalMovableController(IDirectionMovable movable)
    {
        return new PlayerDirectionalMovableController(movable);
    }

    public PlayerDirectionalRotatableController CreatePlayerDirectionalRotatableController(IDirectionRotatable rotatable)
    {
        return new PlayerDirectionalRotatableController(rotatable);
    }

    public PlayerShootableController CreatePlayerShootableController(IShootable shootable)
    {
        return new PlayerShootableController(shootable);
    }

    public CompositeController CreateCompositeController(Controller[] controllers)
    {
        return new CompositeController(controllers);
    }

    public CompositeController CreateMainHeroController(
        Character character)
    {
        return new CompositeController(
            CreatePlayerDirectionalMovableController(character),
            CreatePlayerDirectionalRotatableController(character),
            CreatePlayerShootableController(character));
    }
}
