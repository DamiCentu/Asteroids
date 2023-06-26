
using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] private GameManager gameManager;
    public override void InstallBindings()
    {
        Container.BindInstance(gameManager).AsSingle();
        
        Container.DeclareSignal<PlayerLifeLostSignal>();
        Container.BindSignal<PlayerLifeLostSignal>().ToMethod<GameManager>(manager => manager.OnPlayerLostLifeSignal).FromResolve();
    }
}
