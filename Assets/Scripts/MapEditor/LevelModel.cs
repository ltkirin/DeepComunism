using Assets.Scripts.MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    
    public LevelModel(int levelWith, int levelHeight)
    {
        levelSize = new LevelSize(levelWith, levelHeight);
        tiles = new List<MapEditorTileScript>();
    }
    [SerializeField]
    private LevelSize levelSize;
    [SerializeField]
    private IList<MapEditorTileScript> tiles;

    public LevelSize LevelSize { get => levelSize; set => levelSize = value; }
    public IList<MapEditorTileScript> Tiles { get => tiles; set => tiles = value; }
}
