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

    public CompositeController CreateCompositeController(Controller[] controllers)
    {
        return new CompositeController(controllers);
    }

    public CompositeController CreateMainHeroController(
        IDirectionMovable movable,
        IDirectionRotatable rotatable)
    {
        return new CompositeController(
            CreatePlayerDirectionalMovableController(movable),
            CreatePlayerDirectionalRotatableController(rotatable));
    }
}
