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

    public CompositeController CreateCompositeController(params Controller[] controllers)
    {
        return new CompositeController(controllers);
    }

    public RandomMovementController CreateRandomMovementController(
        IDirectionMovable movable, 
        float minTimeToChangeDirection, 
        float maxTimeToChangeDirection)
    {
        return new RandomMovementController(movable, minTimeToChangeDirection, maxTimeToChangeDirection);
    }

    public AlongMovableVelocityRotatableController CreateAlongMovableVelocityRotatableController(
        IDirectionMovable movable, 
        IDirectionRotatable rotatable)
    {
        return new AlongMovableVelocityRotatableController(movable, rotatable);
    }

    public CompositeController CreateMainHeroController(
        Character character)
    {
        return new CompositeController(
            CreatePlayerDirectionalMovableController(character),
            CreatePlayerDirectionalRotatableController(character),
            CreatePlayerShootableController(character));
    }

    public CompositeController CreateEnemyRandomPassiveWandererController(
        IDirectionMovable movable, 
        IDirectionRotatable rotatable, 
        float minTimeToChangeDirection, 
        float maxTimeToChangeDirection)
    {
        return new CompositeController(
            CreateRandomMovementController(movable, minTimeToChangeDirection, maxTimeToChangeDirection),
            CreateAlongMovableVelocityRotatableController(movable, rotatable));
    }
}
