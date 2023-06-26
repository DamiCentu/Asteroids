using UnityEngine;

public class AsteroidSpawnHandler : AbstractSpawnHandler
{
    private const int MAX_ASTEROID_LIFE_CYCLE = 3; //This is hardcoded, we should get it from a config.
    private const int AMOUNT_OF_ASTEROIDS_TO_SPAWN_AFTER_HIT = 2; //This is hardcoded, we should get it from a config.
    
    public AsteroidSpawnHandler(ObstacleScriptableSpawnConfig config) : base(config) { }
    
    public override void DestroyAll()
    {
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            AsteroidObstacle obstacle = activeObstacles[i] as AsteroidObstacle;
            obstacle.OnDestroyed -= OnAsteroidDestroyed;
            activeObstacles.Remove(obstacle);
            Object.Destroy(obstacle.gameObject);
        }
    }
    
    protected override void SpawnObstacle(AbstractObstacleSpawnData spawnData)
    {
        AsteroidObstacleSpawnData asteroidObstacleSpawnData = spawnData as AsteroidObstacleSpawnData;
        AsteroidObstacle asteroidObstacle = ObstacleFactory.Create() as AsteroidObstacle;

        asteroidObstacle.LifeCycle = asteroidObstacleSpawnData.LifeCycle;
        
        Transform asteroidTransform = asteroidObstacle.transform;
        asteroidTransform.position = asteroidObstacleSpawnData.SpawnPosition;
        asteroidTransform.rotation = asteroidObstacleSpawnData.SpawnRotation;
        float scaleFactor = (float)asteroidObstacle.LifeCycle / (float)MAX_ASTEROID_LIFE_CYCLE;
        Vector3 scale = scaleFactor * asteroidTransform.localScale;
        asteroidTransform.localScale = scale; //This will not work with a pool unless in the restart of the object we reset it's scale to the default.
        
        activeObstacles.Add(asteroidObstacle);

        asteroidObstacle.OnDestroyed += OnAsteroidDestroyed;
    }

    private void OnAsteroidDestroyed(AbstractDestroyData destroyData)
    {
        AsteroidObstacle asteroidObstacle = ((AsteroidDestroyData)destroyData).AsteroidObstacle;

        asteroidObstacle.OnDestroyed -= OnAsteroidDestroyed;
        activeObstacles.Remove(asteroidObstacle);
        Object.Destroy(asteroidObstacle.gameObject);

        if (asteroidObstacle.LifeCycle > 1)
        {
            SpawnObstaclesAfterObstacleDestruction(asteroidObstacle);
        }
    }

    private void SpawnObstaclesAfterObstacleDestruction(AsteroidObstacle asteroidObstacle)
    {
        for (int i = 0; i < AMOUNT_OF_ASTEROIDS_TO_SPAWN_AFTER_HIT; i++) //This is hardcoded, we should get it from a config.
        {
            AsteroidObstacleSpawnData spawnData = new AsteroidObstacleSpawnData()
            {
                SpawnPosition = asteroidObstacle.transform.position,
                SpawnRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)),
                LifeCycle = asteroidObstacle.LifeCycle - 1,
            };
            SpawnObstacle(spawnData);
        }
    }

    protected override AbstractObstacleSpawnData AutomaticSpawnData
    {
        get
        {
            AsteroidObstacleSpawnData spawnData = new AsteroidObstacleSpawnData()
            {
                SpawnPosition = CameraHelper.GetRandomSpawnPosition((ScreenSides)Random.Range(0, 4), Config.SpawnOffsetFromBorders),
                SpawnRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)),
                LifeCycle = MAX_ASTEROID_LIFE_CYCLE, //This is hardcoded, we should get it from a config.
            };

            return spawnData;
        }
    }
}