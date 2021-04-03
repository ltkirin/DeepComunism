using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    public class MapEditorScript : MonoBehaviour
    {
        [SerializeField]
        private int fieldWIdth;
        [SerializeField]
        private int fieldHeight;
        [SerializeField]
        private GameObject tilePrefab;
        [SerializeField]
        private TileTemplateScriptableObject[] tileTemplates;
        [SerializeField]
        private string saveFolderPath;
        [SerializeField]
        private string mapName;
        [SerializeField]
        private LevelScripatbleObject level;

        private MapEditorTileScript[,] tilesMatrix;

        public string SaveFolderPath => saveFolderPath;

        public LevelScripatbleObject Level => level;

        public void GeneraTeEmptyGrid()
        {
            level = null;
            ClearGrid();
            transform.position = new Vector2(-fieldWIdth / 2, fieldHeight / 2);
            tilesMatrix = new MapEditorTileScript[fieldWIdth, fieldHeight];

            for (int i = 0; i < fieldWIdth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    var currentTileObject = PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                    currentTileObject.transform.position = new Vector3(transform.position.x + (currentTileObject.transform.localScale.x * (i + .5f)),
                        transform.position.y - (currentTileObject.transform.localScale.y * (j + .5f)));

                    currentTileObject.transform.SetParent(this.transform);
                    var currentTile = currentTileObject.GetComponent<MapEditorTileScript>();
                    currentTile.MapEditorTileScriptableObjects = tileTemplates;
                    currentTile.SetData(TileType.Standart);
                    currentTile.XCoordinate = i;
                    currentTile.YCoordinate = j;
                    tilesMatrix[i, j] = currentTile;
                }
            }


        }

        public void ClearGrid()
        {
            if (transform.childCount > 0)
            {
                if (tilesMatrix == null || tilesMatrix.Length == 0 || MatrixContentIsNull())
                {
                    var childTiles = transform.GetComponentsInChildren<MapEditorTileScript>();
                    foreach (var tile in childTiles)
                    {
                        DestroyImmediate(tile.gameObject);
                    }

                }

                else
                {
                    for (int i = 0; i < tilesMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < tilesMatrix.GetLength(1); j++)
                        {
                            var forRemove = tilesMatrix[i, j];
                            if (forRemove != null)
                            {
                                DestroyImmediate(forRemove.gameObject);
                            }
                            tilesMatrix[i, j] = null;

                        }
                    }

                }

            }

            transform.position = Vector2.zero;
            mapName = string.Empty;
        }

        public void SaveMap()
        {

            if (tilesMatrix == null || tilesMatrix.GetLength(0) < 1 || tilesMatrix.GetLength(1) < 1)
            {
                var childTiles = transform.GetComponentsInChildren<MapEditorTileScript>();
                if (childTiles.Any())
                {
                    tilesMatrix = new MapEditorTileScript[childTiles.Select(i => i.XCoordinate).Max() + 1, childTiles.Select(i => i.YCoordinate).Max() + 1];
                    foreach (var childTile in childTiles)
                    {
                        tilesMatrix[childTile.XCoordinate, childTile.YCoordinate] = childTile;
                    }

                }
                else
                {
                    tilesMatrix = new MapEditorTileScript[0, 0];
                }
            }
            if (tilesMatrix.Length > 0)
            {
                var count = AssetDatabase
                .FindAssets("", new[] { SaveFolderPath })
                .Length;
                if (string.IsNullOrEmpty(mapName))
                {

                    mapName = $"Level {count}";
                }
                LevelScripatbleObject levelScripatble = ScriptableObject.CreateInstance<LevelScripatbleObject>();
                levelScripatble.LevelIndex = count;
                levelScripatble.LevelName = mapName;
                levelScripatble.LevelWidth = fieldWIdth;
                levelScripatble.LevelHeight = fieldHeight;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < tilesMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < tilesMatrix.GetLength(1); j++)
                    {
                        var tileForSave = tilesMatrix[i, j];
                        levelScripatble.Tiles.Add(JsonUtility.ToJson(tilesMatrix[i, j]));
                    }
                }
                string path = $"Assets/Levels/{mapName}.asset";
                AssetDatabase.CreateAsset(levelScripatble, path);
                AssetDatabase.SaveAssets();
            }
        }



        public void LoadGrid(string path)
        {
            ClearGrid();
            var asset = AssetDatabase.LoadAssetAtPath<LevelScripatbleObject>(path);
            level = asset;
            mapName = asset.LevelName;
            fieldWIdth = asset.LevelWidth;
            fieldHeight = asset.LevelHeight;
            transform.position = new Vector2(-fieldWIdth / 2, fieldHeight / 2);
            tilesMatrix = new MapEditorTileScript[fieldWIdth, fieldHeight];

            foreach (var tileString in asset.Tiles)
            {
                TileLoadingModel loadedTile = JsonUtility.FromJson<TileLoadingModel>(tileString);

                var currentTileObject = PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                currentTileObject.transform.position = new Vector3(transform.position.x + (currentTileObject.transform.localScale.x * loadedTile.xCoordinate),
                  transform.position.y - (currentTileObject.transform.localScale.y * loadedTile.yCoordinate));

                currentTileObject.transform.SetParent(transform);

                currentTileObject.transform.SetParent(transform);
                var currentTile = currentTileObject.GetComponent<MapEditorTileScript>();
                currentTile.MapEditorTileScriptableObjects = tileTemplates;
                currentTile.SetData(loadedTile);
                tilesMatrix[loadedTile.xCoordinate, loadedTile.yCoordinate] = currentTile;

            }
        }

        private bool MatrixContentIsNull()
        {
            for (int i = 0; i < tilesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < tilesMatrix.GetLength(1); j++)
                {
                    if (tilesMatrix[i, j] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}





