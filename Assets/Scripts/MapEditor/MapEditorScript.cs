using Assets.Scripts.Enums;
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
        private TileScriptableObject[] scripatbleObjects;
        [SerializeField]
        private string saveFolderPath;
        [SerializeField]
        private string mapName;

        private MapEditorTileScript[,] tilesMatrix;

        public void GeneraTeEmptyGrid()
        {

            ClearGrid();
            transform.position = new Vector2(-fieldWIdth / 2, fieldHeight / 2);
            tilesMatrix = new MapEditorTileScript[fieldWIdth, fieldHeight];
            
            for (int i = 0; i < fieldWIdth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    var currentTileObject = PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                    currentTileObject.transform.position = new Vector3(transform.position.x + (currentTileObject.transform.localScale.x * (i+.5f)),
                        transform.position.y - (currentTileObject.transform.localScale.y * (j + .5f)));

                    currentTileObject.transform.SetParent(this.transform);
                    var currentTile = currentTileObject.GetComponent<MapEditorTileScript>();
                    currentTile.MapEditorTileScriptableObjects = scripatbleObjects;
                    currentTile.SetData(TileType.Standart);
                    currentTile.XCoordiante = i;
                    currentTile.YCoordiante = j;
                    tilesMatrix[i, j] = currentTile;
                }
            }
        }

        public void ClearGrid()
        {
            if (transform.childCount > 0)
            {
                if (tilesMatrix == null || tilesMatrix.Length == 0)
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
                            var forRemove = tilesMatrix[i, j].gameObject;
                            tilesMatrix[i, j] = null;
                            DestroyImmediate(forRemove);
                        }
                    }

                }
            }
            tilesMatrix = new MapEditorTileScript[0, 0];
            transform.position = Vector2.zero;
        }

        public void SaveMap()
        {
            if (tilesMatrix == null || tilesMatrix.GetLength(0) < 1 || tilesMatrix.GetLength(1) < 1)
            {
                var childTiles = transform.GetComponentsInChildren<MapEditorTileScript>();
                if (childTiles.Any())
                {
                    tilesMatrix = new MapEditorTileScript[childTiles.Select(i => i.XCoordiante).Max() + 1, childTiles.Select(i => i.YCoordiante).Max() + 1];
                    foreach (var childTile in childTiles)
                    {
                        tilesMatrix[childTile.XCoordiante, childTile.YCoordiante] = childTile;
                    }

                }
                else
                {
                    tilesMatrix = new MapEditorTileScript[0, 0];
                }
            }
            if (tilesMatrix.Length > 0)
            {
                bool folderSelected = false;
                while (!folderSelected)
                {
                    saveFolderPath = EditorUtility.OpenFolderPanel("Выберете папку для сохранения", saveFolderPath, "");
                    if (string.IsNullOrEmpty(mapName))
                    {
                        mapName = "NewMap";
                    }
                    if (File.Exists((Path.Combine(saveFolderPath, $"{mapName}.mpf"))))
                    {
                       folderSelected = EditorUtility.DisplayDialog("Файл существует", "Аналогичный файл уже существует. Перезаписать?", "Перезаписать", "Отмена");
                    }
                    else
                    {
                        folderSelected = true;
                    }
                }
                using (StreamWriter sw = new StreamWriter((Path.Combine(saveFolderPath, $"{mapName}.mpf"))))
                {
                    sw.WriteLine($"{fieldWIdth},{fieldHeight}");
                    for (int i = 0; i < tilesMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < tilesMatrix.GetLength(1); j++)
                        {
                            sw.WriteLine(JsonUtility.ToJson(tilesMatrix[i, j]));
                        }
                    }
                }
            }
        }

        public void LoadGrid()
        {
            string path = EditorUtility.OpenFilePanel("Выберите файл для загрузки", saveFolderPath, "*.mpf");

            if (File.Exists(path))
            {
                ClearGrid();
                transform.position = new Vector2(-fieldWIdth / 2, fieldHeight / 2);
                mapName = path.Split('/').Last().Split('.').First();
                using (StreamReader reader = new StreamReader(path))
                {
                    var extensions = reader.ReadLine().Split(',').Select(i => int.Parse(i)).ToArray();
                    fieldWIdth = extensions.First();
                    fieldHeight = extensions.Last();

                    tilesMatrix = new MapEditorTileScript[fieldWIdth, fieldHeight];
                    while (!reader.EndOfStream)
                    {
                        var str = reader.ReadLine();
                        var loadedTile = JsonUtility.FromJson<TileLoadingModel>(str);
                        var currentTileObject = PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                        currentTileObject.transform.position = new Vector3(transform.position.x + (currentTileObject.transform.localScale.x * loadedTile.xCoordiante),
                            transform.position.y - (currentTileObject.transform.localScale.y * loadedTile.yCoordiante));

                        currentTileObject.transform.SetParent(transform);

                        currentTileObject.transform.SetParent(transform);
                        var currentTile = currentTileObject.GetComponent<MapEditorTileScript>();
                        currentTile.MapEditorTileScriptableObjects = scripatbleObjects;
                        currentTile.SetData(loadedTile);
                        tilesMatrix[loadedTile.xCoordiante, loadedTile.yCoordiante] = currentTile;
                    }
                }

            }
        }
    }
}





