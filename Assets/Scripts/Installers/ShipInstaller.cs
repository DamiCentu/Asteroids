using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShipInstaller : MonoInstaller
{
    [SerializeField] private AbstractProjectile bulletPrefab;
    [SerializeField] private List<ScriptableObject> ToInject;
    [SerializeField] private Rigidbody2D rigidbody2D;

    public override void InstallBindings()
    {
        Container.Bind<Rigidbody2D>().FromInstance(rigidbody2D).AsSingle();

        Container.BindInstance(bulletPrefab).WhenInjectedInto<DiAbstractProjectileFactory>();
        Container.Bind<IFactory<AbstractProjectile>>().To<DiAbstractProjectileFactory>().AsSingle();
        
        foreach (ScriptableObject objectToInject in ToInject)
        {
            Container.QueueForInject(objectToInject);
        }
    }
}