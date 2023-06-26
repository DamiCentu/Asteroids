using Zenject;

public class Player : AbstractPlayer, IOwner
{
    private ILifeHandler LifeHandler { get; set; }
    private SignalBus SignalBus { get; set; }

    [Inject]
    public void Construct(ILifeHandler lifeHandler, IControllable controllable, SignalBus signalBus)
    {
        LifeHandler = lifeHandler;
        ControllableObject = controllable;
        SignalBus = signalBus;
    }

    private void Start()
    {
        Bind();
    }

    private void OnDestroy()
    {
        DoUnbind();
    }

    private void Bind()
    {
        if (ControllableObject is IDestroyable outOfLivesNotifier)
        {
            outOfLivesNotifier.OnDestroyed += OnControllableDestroyed;
        }
    }

    private void DoUnbind()
    {
        if (ControllableObject is IDestroyable outOfLivesNotifier)
        {
            outOfLivesNotifier.OnDestroyed -= OnControllableDestroyed;
        }
    }

    private void OnControllableDestroyed(AbstractDestroyData abstractDestroyData)
    {
        LifeHandler.ReduceLives(1);
        DispatchPlayerLostLifeSignal(1, LifeHandler.CurrentLives, LifeHandler.IsOutOfLives);
    }
    
    private void DispatchPlayerLostLifeSignal(int amountLost, int currentLives, bool isOutOfLives)
    {
        PlayerLifeLostSignal lifeLostSignal = new PlayerLifeLostSignal()
        {
            AmountLost = amountLost,
            IsOutOfLives = isOutOfLives,
            CurrenLives = currentLives
        };
        
        SignalBus.Fire(lifeLostSignal);
    }

    public string Id => GetType().ToString(); //This is for the sake of the prototype.
}