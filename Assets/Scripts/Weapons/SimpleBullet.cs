public class SimpleBullet : AbstractProjectile
{
    private void Start()
    {
        Destroy(gameObject, 5f); //For the sake of the prototype. Bullets can be destroyed by reaching the screen edge.
    }

    protected override AbstractHitData GetHitData(IHittable hittable)
    {
        AbstractHitData hitData = new BaseHitData()
        { 
            HitDamage = 1,
            Owner = ObjectOwner,
        };

        return hitData;
    }
}