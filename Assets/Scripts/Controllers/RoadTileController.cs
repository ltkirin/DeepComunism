using Assets.Scripts.Enums;
using Assets.Scripts.MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controllers
{
    public class RoadTileController : TileControllerBase
    {
        public RoadTileController(int matrixXCoordinate, int matrixYCoordinate, TileScriptableObject data) : base(matrixXCoordinate, matrixYCoordinate, data)
        {
            interaction = new RoadInteraction(this);
        }


    }
}
