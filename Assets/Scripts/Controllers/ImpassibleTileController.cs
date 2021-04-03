using Assets.Scripts.Enums;
using Assets.Scripts.MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controllers
{
    public class ImpassibleTileController : TileControllerBase
    {
        public ImpassibleTileController(int matrixXCoordinate, int matrixYCoordinate, TileTemplateScriptableObject data) : base(matrixXCoordinate, matrixYCoordinate, data)
        {
        }

    }
}
