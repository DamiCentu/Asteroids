public class LifeHandler : ILifeHandler
{
    public LifeHandler(int maxLives)
    {
        MaxLives = maxLives;
        SetLivesToMax();
    }

    public void SetLivesToMax()
    {
        CurrentLives = MaxLives;
    }

    public void ReduceLives(int amountToReduce)
    {
        CurrentLives -= amountToReduce;
    }

    public bool IsOutOfLives => CurrentLives <= 0;
    
    public int CurrentLives { get; private set; }

    public int MaxLives { get; }
}