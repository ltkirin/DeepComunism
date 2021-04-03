using Assets.Scripts.MapEditor;

namespace Assets.Scripts.Controllers
{
    public class DangerousTileController : TileControllerBase
    {
        public DangerousTileController(int matrixXCoordinate, int matrixYCoordinate, TileScriptableObject data) 
            : base(matrixXCoordinate, matrixYCoordinate, data)
        {
        }

    }
}
