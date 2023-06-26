using UnityEngine;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    [SerializeField] private InputService inputServiceInstance;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        
        Container.Bind<IInputService>().FromInstance(inputServiceInstance).AsSingle().NonLazy();
        Container.DeclareSignal<InputSignal>();
    }
}
