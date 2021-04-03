using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    [CreateAssetMenu(fileName = "New TileData", menuName = "Tile Data", order = 51)]
    public class TileScriptableObject : ScriptableObject
    {
        [SerializeField]
        private TileType type;
        [SerializeField]
        private Color color;
        [SerializeField]
        private Sprite tileSprite;
        [SerializeField]
        private float velocity;

        public TileType Type { get => type; set => type = value; }
        public Color Color { get => color; set => color = value; }
        public float Velocity { get => velocity; set => velocity = value; }
        public Sprite TileSprite { get => tileSprite; set => tileSprite = value; }
    }
}
