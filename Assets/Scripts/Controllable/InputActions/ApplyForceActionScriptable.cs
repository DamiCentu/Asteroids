using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ApplyForceScriptable", menuName = "Scriptable/InputActions/ApplyForceAction")]
public class ApplyForceActionScriptable : AbstractInputActionScriptable
{
    [SerializeField] private float thrustForce = 3f;
    [SerializeField] private float maxThrustSpeed = 6f;
    [SerializeField] private ForceMode2D forceMode2D = ForceMode2D.Force;

    [Inject] private Rigidbody2D Rigidbody { get; set; }
    
    public override void ApplyInput(Transform Transform, float inputValue = 1)
    {
        if (inputValue > 0f)
        {
            Vector2 thrustForceVector = Transform.right * thrustForce * inputValue;
            Rigidbody.AddForce(thrustForceVector, forceMode2D);
            
            Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, maxThrustSpeed);
        }
    }

    public override void ResetAction()
    {
        Rigidbody.velocity = Vector2.zero;
    }
}