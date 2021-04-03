using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interaction
{
    public abstract class AddonInteractionBase : IAddonInteraction
    {
        private readonly ITileInteraction parentInteraction;

        protected AddonInteractionBase(ITileInteraction parentInteraction)
        {
            this.parentInteraction = parentInteraction;
        }

        public ITileInteraction ParentInteraction => parentInteraction;

        public abstract IEnumerator ExecuteInteraction(IInteractableCharacter target);
    }
}
