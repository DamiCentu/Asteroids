using Zenject;

public class DiUiLifeFactory : IFactory<UiLife>
{
    private readonly DiContainer container;
    private readonly UiLife life;

    public DiUiLifeFactory(DiContainer container, UiLife life)
    {
        this.container = container;
        this.life = life;
    }

    public UiLife Create()
    {
        return container.InstantiatePrefab(life).GetComponent<UiLife>();
    }
}