using Assets.Scripts.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interaction
{
    public abstract class InteractionBase<TTileController> where TTileController : TileControllerBase
    {
        protected readonly TTileController controller;

        protected InteractionBase(TTileController controller)
        {
            this.controller = controller;
        }
    }
}
