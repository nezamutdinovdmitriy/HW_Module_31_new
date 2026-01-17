public class AlongMovableVelocityRotatableController : Controller
{
    private readonly IDirectionMovable _movable;
    private readonly IDirectionRotatable _rotatable;

    public AlongMovableVelocityRotatableController(IDirectionMovable movable, IDirectionRotatable rotatable)
    {
        _movable = movable;
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.SetRotationDirection(_movable.CurrentVelocity);
    }
}
