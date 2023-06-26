using UnityEngine;

public class Rigidbody2DOffScreenRepositionComponent : OffScreenRepositionComponent
{
    [SerializeField] private Rigidbody2D rigidbody;
    
    public override Vector3 ObjectDirection => rigidbody.velocity;
}