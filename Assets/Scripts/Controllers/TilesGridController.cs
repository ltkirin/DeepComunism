using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MapEditor;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class TilesGridController : ControllerBase, IStartController
    {
        private ITileController[,] matrix;

        private readonly string filePath;
        private readonly IList<TileTemplateScriptableObject> scriptableObjects;

        public TilesGridController(string filePath, IList<TileTemplateScriptableObject> scriptableObjects)
        {
            this.filePath = filePath;
            this.scriptableObjects = scriptableObjects;
        }

        public ITileController[,] Matrix { get => matrix; set => matrix = value; }

        public void Start()
        {
            State = ControllerState.Loading;
            var asset = AssetDatabase.LoadAssetAtPath<LevelScripatbleObject>(filePath);

            matrix = new ITileController[asset.LevelWidth, asset.LevelHeight];

            foreach (var tileString in asset.Tiles)
            {
                TileLoadingModel loadedTile = JsonUtility.FromJson<TileLoadingModel>(tileString);

                matrix[loadedTile.xCoordinate, loadedTile.yCoordinate] = GetTileController(loadedTile);

            }
            State = ControllerState.Active;
            IsActive = true;
        }

        public IList<ITileController> GetAdjacentTiles(ITileController tile, params Direction[] directions)
        {
            List<ITileController> result = new List<ITileController>();
            if (directions == null)
            {
                directions = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
            }
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if (tile.MatrixYCoordinate > 0)
                        {
                            result.Add(matrix[tile.MatrixXCoordinate, tile.MatrixYCoordinate - 1]);
                        }
                        break;
                    case Direction.Right:
                        if (tile.MatrixXCoordinate < matrix.GetLength(0) - 1)
                        {
                            result.Add(matrix[tile.MatrixXCoordinate + 1, tile.MatrixYCoordinate]);
                        }
                        break;
                    case Direction.Down:
                        if (tile.MatrixYCoordinate < matrix.GetLength(1) - 1)
                        {
                            result.Add(matrix[tile.MatrixXCoordinate, tile.MatrixYCoordinate + 1]);
                        }
                        break;
                    case Direction.Left:
                        if (tile.MatrixXCoordinate > 0)
                        {
                            result.Add(matrix[tile.MatrixXCoordinate - 1, tile.MatrixYCoordinate]);
                        }
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        private ITileController GetTileController(TileLoadingModel model)
        {
            ITileController result = null;
            TileTemplateScriptableObject scriptableObject = scriptableObjects.First(i => i.Type == model.type);
            switch (model.type)
            {
                case TileType.Standart:
                    result = new RoadTileController(model.xCoordinate, model.yCoordinate, scriptableObject);
                    break;
                case TileType.Fast:
                    result = new RailRoadTileController(model.xCoordinate, model.yCoordinate, scriptableObject);
                    break;
                case TileType.Impassable:
                    result = new ImpassibleTileController(model.xCoordinate, model.yCoordinate, scriptableObject);
                    break;
                case TileType.Dangerous:
                    result = new DangerousTileController(model.xCoordinate, model.yCoordinate, scriptableObject);
                    break;
            }
            if (model.addon > TileAddon.None)
            {
                result.SetAddon(model.addon);
            }
            result.IsStartTile = model.isStartTile;
            result.IsFinishTile = model.isFinishTile;
            return result;
        }
    }
}
