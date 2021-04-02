using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    public class MapEditorTileScript : MonoBehaviour
    {
        [SerializeField]
        private int xCoordiante;
        [SerializeField]
        private int yCoordiante;
        [SerializeField]
        private bool isStartTile;
        [SerializeField]
        private bool isFinishTitle;
        [SerializeField]
        private TileAddon addon = TileAddon.None;
        [SerializeField]
        private TileType type = TileType.Impassable;

        private MapEditorTileScriptableObject data;

        private MeshRenderer innerMeshRenderer;

        public IList<MapEditorTileScriptableObject> MapEditorTileScriptableObjects { get; set; }
        private MeshRenderer meshRenderer
        {
            get
            {
                if (innerMeshRenderer == null)
                {
                    innerMeshRenderer = transform.GetComponent<MeshRenderer>();

                }
                return innerMeshRenderer;
            }
        }
        [SerializeField]
        public int XCoordiante { get => xCoordiante; set => xCoordiante = value; }
        public int YCoordiante { get => yCoordiante; set => yCoordiante = value; }

        public bool IsStartTile { get => isStartTile; set => isStartTile = value; }
        public bool IsFinishTitle { get => isFinishTitle; set => isFinishTitle = value; }
        public TileAddon Addon { get => addon; set => addon = value; }
        public TileType Type { get => type; set => type = value; }

        private void OnValidate()
        {
            if (data != null && data.Type != type)
            {
                SetData(type);
            }
        }

        public void SetData(TileType type)
        {
            this.type = type;
            data = MapEditorTileScriptableObjects.First(x => x.Type == this.type);
            meshRenderer.sharedMaterial = GetMaterial(data.Color);
        }

        public void SetData(TileLoadingModel script)
        {
            XCoordiante = script.xCoordiante;
            yCoordiante = script.yCoordiante;
            SetData(script.type);
        }

        public void RefreshColor()
        {
            meshRenderer.sharedMaterial = GetMaterial(data.Color);
        }

        private Material GetMaterial(Color color)
        {
            var result = new Material(meshRenderer.sharedMaterial.shader);
            result.color = color;
            return result;
        }

    }
}
