using UnityEngine;
using Zenject;

public class ScreenRepositionInstaller : MonoInstaller
{
    [SerializeField] private OffScreenRepositionManager OffScreenRepositionManager;
    public override void InstallBindings()
    {
        Container.Bind<IOffScreenRepositionManager>().FromInstance(OffScreenRepositionManager).AsSingle();
    }
}
