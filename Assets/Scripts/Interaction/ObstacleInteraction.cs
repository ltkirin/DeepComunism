using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interaction
{
    public class ObstacleInteraction : AddonInteractionBase
    {
        public ObstacleInteraction(ITileInteraction parentInteraction) : base(parentInteraction)
        {
        }

        public override IEnumerator ExecuteInteraction(IInteractableCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
