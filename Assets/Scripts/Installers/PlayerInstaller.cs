using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField] private Player Player;
    [SerializeField] private Ship Ship;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(Player).AsSingle();
        Container.BindSignal<InputSignal>().ToMethod<Player>(player => player.OnInputSignal).FromResolve();
        Container.Bind<ILifeHandler>().To<LifeHandler>().AsSingle().WithArguments(3);

        Container.Bind<IOwner>().To<Player>().FromInstance(Player);
        Container.Bind<IControllable>().To<Ship>().FromInstance(Ship);
    }
}