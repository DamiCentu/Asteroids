using UnityEngine;

[CreateAssetMenu(fileName = "RotateScriptable", menuName = "Scriptable/InputActions/RotateAction")]
public class RotateActionScriptable : AbstractInputActionScriptable
{
    [SerializeField] private float rotationSpeed = 180f;

    public override void ApplyInput(Transform Transform, float inputValue = 1)
    {
        float rotationAmount = inputValue * rotationSpeed * Time.fixedDeltaTime;
        Transform.Rotate(0f, 0f, -rotationAmount);
    }
}