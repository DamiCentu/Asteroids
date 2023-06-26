using UnityEngine;
using Zenject;

public class UILifeHandlerInstaller : MonoInstaller
{
    [SerializeField] private UILivesHandler uiLivesHandler;
    [SerializeField] private UiLife lifePrefab;
    public override void InstallBindings()
    {
        Container.BindInstance(uiLivesHandler).AsSingle();
    
        Container.BindInstance(lifePrefab).WhenInjectedInto<DiUiLifeFactory>();
        Container.Bind<IFactory<UiLife>>().To<DiUiLifeFactory>().AsSingle();

        Container.BindSignal<PlayerLifeLostSignal>().ToMethod<UILivesHandler>((livesHandler) => livesHandler.OnPlayerLifeLostSignal).FromResolve();
    }
}