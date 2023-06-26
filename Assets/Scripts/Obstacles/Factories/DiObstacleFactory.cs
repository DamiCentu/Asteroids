using Zenject;

public class DiObstacleFactory : IFactory<AbstractObstacle>
{
    private readonly DiContainer container;
    private readonly AbstractObstacle obstaclePrefab;

    public DiObstacleFactory(DiContainer container, AbstractObstacle obstaclePrefab)
    {
        this.container = container;
        this.obstaclePrefab = obstaclePrefab;
    }

    public AbstractObstacle Create()
    {
        return container.InstantiatePrefab(obstaclePrefab).GetComponent<AbstractObstacle>();
    }
}