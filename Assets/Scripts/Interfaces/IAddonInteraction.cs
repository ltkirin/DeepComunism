namespace Assets.Scripts.Interfaces
{
    public interface IAddonInteraction : ITileInteraction
    {
        ITileInteraction ParentInteraction { get; }
    }
}
