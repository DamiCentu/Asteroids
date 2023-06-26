using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidObstacle : AbstractObstacle, IHittable, IDestroyable
{
    [SerializeField] private Rigidbody2D asteroidRigidbody;
    [SerializeField] private float minForce = 1f;
    [SerializeField] private float maxForce = 4f;

    public event Action<AbstractDestroyData> OnDestroyed;
    public int LifeCycle { get; set; }

    public void OnHit(AbstractHitData data)
    {
        if (data.Owner == null || string.IsNullOrEmpty(data.Owner.Id)) // Here we can extend to other owners. For now not empty will be the player.
        {
            return;
        }
        
        AsteroidDestroyData destroyData = new AsteroidDestroyData()
        {
            AsteroidObstacle = this
        };
        OnDestroyed?.Invoke(destroyData);
    }

    private void Start()
    {
        AddForce(Random.insideUnitCircle);
    }

    private void AddForce(Vector2 direction)
    {
        float spawnForce = Random.Range(minForce, maxForce);
        asteroidRigidbody.AddForce(direction * spawnForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        IHittable hittable = collider2d.GetComponent<IHittable>();
        if (hittable != null)
        {
            AbstractHitData hitData = GetHitData(hittable);
            hittable.OnHit(hitData);
        }
    }
    
    private AbstractHitData GetHitData(IHittable hittable)
    {
        AbstractHitData hitData = new BaseHitData()
        { 
            HitDamage = 1
        };

        return hitData;
    }
}
