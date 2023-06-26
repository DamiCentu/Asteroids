
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ShootActionScriptable", menuName = "Scriptable/InputActions/ShootAction")]
public class ShootActionScriptable : AbstractInputActionScriptable
{
    [SerializeField] private float bulletForce = 7f;

    [Inject] private IFactory<AbstractProjectile> ProjectileFactory { get; }
    public override void ApplyInput(Transform bulletSpawn, float inputValue = 1)
    {
        AbstractProjectile bullet = ProjectileFactory.Create();
        
        Transform bulletTransform = bullet.transform;
        bulletTransform.position = bulletSpawn.position;
        bulletTransform.rotation = bulletSpawn.rotation;
        bulletTransform.SetParent(null, true);
        
        bullet.AddForce(bulletSpawn.right * bulletForce, ForceMode2D.Impulse);
    }
}