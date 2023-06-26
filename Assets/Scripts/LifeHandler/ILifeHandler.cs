
public interface ILifeHandler
{
    int CurrentLives { get; }
    int MaxLives { get; }
    void SetLivesToMax();
    void ReduceLives(int amountToReduce);
    bool IsOutOfLives { get; }
}