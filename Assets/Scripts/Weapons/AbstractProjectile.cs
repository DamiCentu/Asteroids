using UnityEngine;
using Zenject;

public abstract class AbstractProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    protected IOwner ObjectOwner { get; private set; }

    [Inject]
    public void Construct(IOwner objectOwner)
    {
        ObjectOwner = objectOwner;
    }
    
    public void AddForce(Vector3 velocity, ForceMode2D impulse)
    {
        rigidbody.AddForce(velocity, impulse);
    }

    protected abstract AbstractHitData GetHitData(IHittable hittable);

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        IHittable hittable = collider2d.GetComponent<IHittable>();
        if (hittable != null)
        {
            AbstractHitData hitData = GetHitData(hittable);
            hittable.OnHit(hitData);
        }
        Destroy(gameObject);
    }
}
