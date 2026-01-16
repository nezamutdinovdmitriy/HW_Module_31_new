using UnityEngine;

public class PlayerShootableController : Controller
{
    private const KeyCode ShootingKey = KeyCode.Space;

    private IShootable _shootable;

    public PlayerShootableController(IShootable shootable)
    {
        _shootable = shootable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetKeyDown(ShootingKey))
            _shootable.Shoot();
    }
}
