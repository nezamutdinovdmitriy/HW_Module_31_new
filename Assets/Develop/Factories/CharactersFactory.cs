using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharactersFactory
{
    public Character CreateRigidbodyCharacter(
        Character characterPrefab,
        Vector3 spawnPosition,
        float moveSpeed,
        float rotationSpeed,
        float maxHealth,
        Projectile projectilePrefab)
    {
        Character instance = Object.Instantiate(characterPrefab, spawnPosition, Quaternion.identity, null);

        if (instance.TryGetComponent(out Rigidbody rigidbody))
        {
            RigidbodyDirectionalMover mover = new(rigidbody, moveSpeed);
            RigidbodyDirectionalRotator rotator = new(rigidbody, rotationSpeed);
            Shooter shooter = new(projectilePrefab);

            instance.Initialize(mover, rotator, maxHealth, shooter);

            return instance;
        }
        else
        {
            throw new InvalidOperationException("Not found Rigidbody component");
        }
    }
}
