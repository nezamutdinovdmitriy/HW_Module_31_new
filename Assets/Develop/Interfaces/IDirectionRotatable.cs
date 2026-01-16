using UnityEngine;

public interface IDirectionRotatable : ITransformPosition
{
    public Quaternion CurrentRotation { get; }
    public void SetRotationDirection(Vector3 inputDirection);
}
