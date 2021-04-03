using Assets.Scripts.Components;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Interfaces
{
    public interface ITileController
    {

        bool IsStartTile { get; set; }
        bool IsFinishTile { get; set; }
        int MatrixXCoordinate { get; }

        int MatrixYCoordinate { get; }

        float MovingVelocity { get; }

        ITilePriamryInteraction Interaction { get; }

        void SetComponent(TileComponent component);

        void SetAddon(TileAddon addonType);

        TileType GetTileType();
    }
}
