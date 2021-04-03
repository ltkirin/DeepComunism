using Assets.Scripts.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MapEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Components
{
    public class TilesGridComponent : ComponentBase
    {
        [SerializeField]
        private string currentLevelPath;
        [SerializeField]
        private float startupDuartion;
        [SerializeField]
        private List<TileScriptableObject> tilesScripatableObjects;
        [SerializeField]
        private List<TileComponent> tileComponents;
        [SerializeField]
        private GameObject tilePrefab;

        private TilesGridController controller;

        private void Awake()
        {
            controller = new TilesGridController(currentLevelPath, tilesScripatableObjects);
            StartCoroutine(CreateFieldView());
        }

        public string CurrentLevelPath { get => currentLevelPath; set => currentLevelPath = value; }

        public IEnumerator CreateFieldView()
        {
            while (controller.State < ControllerState.Active)
            {
                yield return new WaitForEndOfFrame();
            }
            int width = controller.Matrix.GetLength(0);
            int height = controller.Matrix.GetLength(1);
            transform.position = new Vector2(-width / 2, height / 2);
            tileComponents = new List<TileComponent>();
            for (int i = 0; i < controller.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < controller.Matrix.GetLength(1); j++)
                {
                    tileComponents.Add(Instantiate(tilePrefab, GetLocation(i, j), Quaternion.identity, transform).GetComponent<TileComponent>());
                    controller.Matrix[i, j].SetComponent(tileComponents.Last());

                }
            }
            ActivateGamefield();
            yield return null;

        }

        public override void Activate()
        {
            base.Activate();
        }

        private void ActivateGamefield()
        {
            foreach (var component in tileComponents)
            {
                StartCoroutine(ActivateTile(component));
            }
        }

        private IEnumerator ActivateTile(TileComponent tile)
        {
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(.1f, startupDuartion));
            tile.Activate();
        }

        private Vector2 GetLocation(int xIndex, int yIndex)
        {

            return new Vector2(transform.position.x + (tilePrefab.transform.lossyScale.x * (xIndex + .5f)),
                        transform.position.y - (tilePrefab.transform.lossyScale.y * (yIndex + .5f)));
        }
    }
}
