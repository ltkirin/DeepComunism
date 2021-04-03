using Assets.Scripts.Components;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MapEditor;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers
{
    public abstract class TileControllerBase : ControllerBase, ITileController
    {
        protected readonly int matrixXCoordinate;
        protected readonly int matrixYCoordinate;
        protected readonly TileTemplateScriptableObject data;
        protected ITilePriamryInteraction interaction;
        protected TileComponent component;

        public int MatrixXCoordinate => matrixXCoordinate;

        public int MatrixYCoordinate => matrixYCoordinate;

        public float MovingVelocity => data.Velocity;

        public ITilePriamryInteraction Interaction => interaction;
        public bool IsStartTile { get ; set ; }
        public bool IsFinishTile { get ; set ; }

        public TileControllerBase(int matrixXCoordinate, int matrixYCoordinate, TileTemplateScriptableObject data)
        {
            this.matrixXCoordinate = matrixXCoordinate;
            this.matrixYCoordinate = matrixYCoordinate;
            this.data = data;
        }

        public void SetComponent(TileComponent component)
        {
            this.component = component;
            component.SetSprite(data.TileSprite);
        }

        public void SetAddon(TileAddon addtonType)
        {
            interaction.SetAddon(addtonType);
        }

        public TileType GetTileType()
        {
            switch (this)
            {
                case RoadTileController r:
                    return TileType.Standart;
                case ImpassibleTileController i:
                    return TileType.Impassable;
                case DangerousTileController d:
                    return TileType.Dangerous;
                case RailRoadTileController d:
                    return TileType.Fast;
                default:
                    throw new Exception("Unexpected type!");
            }
        }
    }
}
