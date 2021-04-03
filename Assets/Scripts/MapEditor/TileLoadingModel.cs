using Assets.Scripts.Enums;
using UnityEngine;

public class TileLoadingModel
{
    [SerializeField]
    public int xCoordiante;
    [SerializeField]
    public int yCoordiante;
    [SerializeField]
    public bool isStartTile;
    [SerializeField]
    public bool isFinishTile;
    [SerializeField]
    public TileAddon addon;
    [SerializeField]
    public TileType type;
}
