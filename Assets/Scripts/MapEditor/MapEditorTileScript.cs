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
        private int xCoordinate;
        [SerializeField]
        private int yCoordinate;
        [SerializeField]
        private bool isStartTile;
        [SerializeField]
        private bool isFinishTitle;
        [SerializeField]
        private TileAddon addon = TileAddon.None;
        [SerializeField]
        private TileType type = TileType.Impassable;

        private TileTemplateScriptableObject data;

        private MeshRenderer innerMeshRenderer;

        public IList<TileTemplateScriptableObject> MapEditorTileScriptableObjects { get; set; }
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
        public int XCoordinate { get => xCoordinate; set => xCoordinate = value; }
        public int YCoordinate { get => yCoordinate; set => yCoordinate = value; }

        public bool IsStartTile { get => isStartTile; set => isStartTile = value; }
        public bool IsFinishTitle { get => isFinishTitle; set => isFinishTitle = value; }
        public TileAddon Addon { get => addon; set => addon = value; }
        public TileType Type { get => type; set => type = value; }

        private void OnValidate()
        {
            try
            {
                if (data != null && data.Type != type)
                {
                    SetData(type);
                }
            }
            catch (Exception e)
            {

            }
        }

        public void SetData(TileType type)
        {
            if (MapEditorTileScriptableObjects == null || !MapEditorTileScriptableObjects.Any())
            {
                SetData(type);

            }
            else
            {
                this.type = type;
                data = MapEditorTileScriptableObjects.First(x => x.Type == this.type);
                meshRenderer.sharedMaterial = GetMaterial(data.Color);
            }
        }

        public void SetData(TileLoadingModel loadingModel)
        {
            XCoordinate = loadingModel.xCoordinate;
            yCoordinate = loadingModel.yCoordinate;
            SetData(loadingModel.type);
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
