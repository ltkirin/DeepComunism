using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
	[CreateAssetMenu(fileName = "New TileData", menuName = "Tile Data", order = 51)]
	public class MapEditorTileScriptableObject : ScriptableObject
	{
		[SerializeField]
		private TileType type;
		[SerializeField]
		private Color color;

		public TileType Type { get => type; set => type = value; }
		public Color Color { get => color; set => color = value; }
	}
}
