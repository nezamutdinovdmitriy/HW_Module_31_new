public class PlayerDeathLoseCondition : GameCondition
{
    private readonly Character _character;

    public PlayerDeathLoseCondition(Character character)
    {
        _character = character;
    }

    public override bool IsMet()
    {
        return _character.IsDestroyed || _character.CurrentHealth <= 0;
    }
}
