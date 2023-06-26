using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UILivesHandler : MonoBehaviour
{
    private const int MAX_LIVES = 3; //This should be injected by the config of the player
    private List<UiLife> allLives = new List<UiLife>();
    private IFactory<UiLife> LifeFactory { get; set; }

    [Inject]
    public void Construct(IFactory<UiLife> obstacleFactory)
    {
        LifeFactory = obstacleFactory;
    }

    private void Awake()
    {
        for (int i = 0; i < MAX_LIVES; i++)
        {
            UiLife life = LifeFactory.Create();
            allLives.Add(life);
        }
    }

    public void OnPlayerLifeLostSignal(PlayerLifeLostSignal signal)
    {
        int livesLost = signal.AmountLost;
        foreach (UiLife uiLife in allLives)
        {
            if (!uiLife.IsActive) continue;
            
            uiLife.Enable(false);
            
            livesLost--;
            if (livesLost <= 0)
            {
                break;
            }
        }
    }
}
