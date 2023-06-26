using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleSpawnManager : MonoBehaviour
{
    private AbstractSpawnHandler[] spawnHandlers;

    [Inject]
    public void Construct(List<AbstractSpawnHandler> handlers)
    {
        spawnHandlers = handlers.ToArray();
    }
    
    public void OnPlayerLostLifeSignal(PlayerLifeLostSignal lostSignal)
    {
        if (!lostSignal.IsOutOfLives)
        {
            foreach (AbstractSpawnHandler spawnHandler in spawnHandlers)
            {
                spawnHandler.DestroyAll();
            }
        }
    }

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        foreach (AbstractSpawnHandler spawnHandler in spawnHandlers)
        {
            StartCoroutine(spawnHandler.StartSpawning());
        }
    }
}