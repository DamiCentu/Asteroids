using Zenject;

public class DiAbstractProjectileFactory : IFactory<AbstractProjectile>
{
    private readonly DiContainer container;
    private readonly AbstractProjectile prefab;

    public DiAbstractProjectileFactory(DiContainer container, AbstractProjectile prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public AbstractProjectile Create()
    {
        return container.InstantiatePrefab(prefab).GetComponent<AbstractProjectile>();
    }
}