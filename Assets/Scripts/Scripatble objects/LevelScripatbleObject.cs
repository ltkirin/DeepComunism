using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    public class LevelScripatbleObject : ScriptableObject
    {
        [SerializeField]
        private int levelIndex;
        [SerializeField]
        private string levelName;
        [SerializeField]
        private int levelWidth;
        [SerializeField]
        private int levelHeight;
        [SerializeField]
        private List<string> tiles = new List<string>();

        public int LevelIndex { get => levelIndex; set => levelIndex = value; }
        public string LevelName { get => levelName; set => levelName = value; }
        public int LevelWidth { get => levelWidth; set => levelWidth = value; }
        public int LevelHeight { get => levelHeight; set => levelHeight = value; }
        public List<string> Tiles { get => tiles; set => tiles = value; }
    }
}
