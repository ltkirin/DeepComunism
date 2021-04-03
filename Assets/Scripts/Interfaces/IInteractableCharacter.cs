using Assets.Scripts.Enums;
using System.Collections;
using System.Numerics;

public interface IInteractableCharacter
{
    IEnumerator Destroy();
    void SetDirection(Direction direction);
    void SetVelocity(float velocity);

    void SetDestinition(Vector2 destinition);

    ITileInteraction CurrentInteraction { get; set; }
}
