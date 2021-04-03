using System;
using System.Collections;

namespace Assets.Scripts.Interaction
{
    public class DisabledRoadInteraction : AddonInteractionBase
    {
        public DisabledRoadInteraction(ITileInteraction parentInteraction) : base(parentInteraction)
        {
        }

        public override IEnumerator ExecuteInteraction(IInteractableCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
