using Assets.Scripts.MapEditor;

namespace Assets.Scripts.Controllers
{
    public class DangerousTileController : TileControllerBase
    {
        public DangerousTileController(int matrixXCoordinate, int matrixYCoordinate, TileTemplateScriptableObject data) 
            : base(matrixXCoordinate, matrixYCoordinate, data)
        {
        }

    }
}
