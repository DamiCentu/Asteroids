using System;
using UnityEngine;
using Zenject;

public class ObstacleSpawnerInstaller : MonoInstaller
{
    [SerializeField] private ObstacleScriptableSpawnConfig[] spawnHandlers;
    [SerializeField] private ObstacleSpawnManager obstacleSpawnManager;
    [SerializeField] private Camera mainCamera;
    public override void InstallBindings()
    {
        Container.Bind<IOrthographicCameraHelper>().To<OrthographicCameraHelper>().AsSingle().WithArguments(mainCamera).NonLazy();
        Container.Bind<IFactory<AbstractObstacle>>().To<DiObstacleFactory>().AsTransient();

        foreach (ObstacleScriptableSpawnConfig scriptableSpawnConfig in spawnHandlers)
        {
            Container.BindInstance(scriptableSpawnConfig.ObstaclePrefab).WhenInjectedInto<DiObstacleFactory>();

            Type typeToCreate = Type.GetType(scriptableSpawnConfig.SpawnHandlerClass);
            Container.Bind<AbstractSpawnHandler>().To(typeToCreate).AsSingle().WithArguments(scriptableSpawnConfig);
        }
        
        Container.BindInstance(obstacleSpawnManager).AsSingle();

        Container.BindSignal<PlayerLifeLostSignal>().ToMethod<ObstacleSpawnManager>((spawner) => spawner.OnPlayerLostLifeSignal).FromResolve();
    }
}