using UnityEngine;

public abstract class AbstractInputActionScriptable : ScriptableObject
{
    public abstract void ApplyInput(Transform Transform, float inputValue = 1);

    public virtual void ResetAction() { }
}