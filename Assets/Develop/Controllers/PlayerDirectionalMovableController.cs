using UnityEngine;

public class PlayerDirectionalMovableController : Controller
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private IDirectionMovable _movable;

    public PlayerDirectionalMovableController(IDirectionMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        _movable.SetMoveDirection(inputDirection);
    }
}
