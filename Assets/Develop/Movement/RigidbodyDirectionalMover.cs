using UnityEngine;

public class RigidbodyDirectionalMover : DirectionalMover
{
    private readonly Rigidbody _rigidbody;

    public RigidbodyDirectionalMover(Rigidbody rigidbody, float moveSpeed) : base(moveSpeed)
    {
        _rigidbody = rigidbody;
    }

    public override void Update(float deltaTime) => _rigidbody.velocity = CurrentVelocity;
}
