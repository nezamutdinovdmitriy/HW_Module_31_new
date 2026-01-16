using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharactersFactory
{
    public Character CreateRigidbodyCharacter(
        Character prefab,
        Vector3 spawnPosition,
        float moveSpeed,
        float rotationSpeed)
    {
        Character instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity, null);

        if(instance.TryGetComponent(out Rigidbody rigidbody))
        {
            RigidbodyDirectionalMover mover = new RigidbodyDirectionalMover(rigidbody, moveSpeed);
            RigidbodyDirectionalRotator rotator = new RigidbodyDirectionalRotator(rigidbody, rotationSpeed);

            instance.Initialize(mover, rotator);

            return instance;
        }
        else
        {
            throw new InvalidOperationException("Not found Rigidbody component");
        }
    }
}
