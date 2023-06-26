using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public abstract class AbstractSpawnHandler
{
    protected readonly List<AbstractObstacle> activeObstacles = new List<AbstractObstacle>(); // Here we should be using a object pool.
    [Inject] protected IOrthographicCameraHelper CameraHelper { get; }
    [Inject] protected IFactory<AbstractObstacle> ObstacleFactory { get; }
    protected ObstacleScriptableSpawnConfig Config { get; }
    
    protected AbstractSpawnHandler(ObstacleScriptableSpawnConfig config)
    {
        Config = config;
    }
    
    public virtual IEnumerator StartSpawning()
    {
        while (true) //Just for the prototype
        {
            SpawnObstacle(AutomaticSpawnData);
            yield return new WaitForSeconds(Random.Range(Config.SpawnMinTimeRate, Config.SpawnMaxTimeRate));
        }
    }

    public abstract void DestroyAll();
    protected abstract void SpawnObstacle([CanBeNull] AbstractObstacleSpawnData spawnData = null);
    protected abstract AbstractObstacleSpawnData AutomaticSpawnData { get; }
}