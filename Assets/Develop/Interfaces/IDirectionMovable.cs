using UnityEngine;

public interface IDirectionMovable : ITransformPosition, IMovable
{
    public void SetMoveDirection(Vector3 inputDirection);
}
