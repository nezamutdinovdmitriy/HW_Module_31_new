using UnityEngine;

public class PlayerDirectionalRotatableController : Controller
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private IDirectionRotatable _rotatable;

    public PlayerDirectionalRotatableController(IDirectionRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        _rotatable.SetRotationDirection(inputDirection);
    }
}
