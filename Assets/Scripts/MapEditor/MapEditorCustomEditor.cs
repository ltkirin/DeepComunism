using Boo.Lang;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
	[CustomEditor(typeof(MapEditorScript))]
	public class MapEditorCustomEditor : Editor
	{
		[SerializeField]
		private MapEditorScript script;

		private List<string> levelsPaths = new List<string>();
		int choiceIndex = 0;
		void OnEnable()
		{
			script = (MapEditorScript)target;
			RefreshLevels();
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			if (GUILayout.Button("Сгенерировать сетку"))
			{
				script.GeneraTeEmptyGrid();
			}	
			if (GUILayout.Button("Очистить сетку"))
			{
				script.ClearGrid();
			}
			if (GUILayout.Button("Сохранить"))
			{
				script.SaveMap();
				RefreshLevels();
			}
			if (GUILayout.Button("Загрузить"))
			{
				script.LoadGrid(levelsPaths[choiceIndex]);
			}

			choiceIndex = EditorGUILayout.Popup(choiceIndex, levelsPaths.Select(i => GetLevelName(i)).ToArray());			
			EditorUtility.SetDirty(target);
		}


		private string GetLevelName(string path) => path.Split('/').Last().Replace(".asset", "");

		private void RefreshLevels()
		{
			levelsPaths.Clear();
			levelsPaths.AddRange(AssetDatabase
				.FindAssets("", new[] { script.SaveFolderPath })
				.Select(i => AssetDatabase.GUIDToAssetPath(i))
				.ToList());
		}
	}
}
