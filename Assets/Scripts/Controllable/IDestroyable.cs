using System;

public interface IDestroyable
{
    event Action<AbstractDestroyData> OnDestroyed;
}