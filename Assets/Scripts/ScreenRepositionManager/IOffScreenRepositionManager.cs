public interface IOffScreenRepositionManager
{
    void Subscribe(IOffScreenRepositionable repositionable);
    void UnSubscribe(IOffScreenRepositionable repositionable);
}