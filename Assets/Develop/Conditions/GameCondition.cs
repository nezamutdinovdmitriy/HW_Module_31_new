using System;

public abstract class GameCondition : IDisposable
{
    public abstract bool IsMet();
    public virtual void Dispose() { }
}
