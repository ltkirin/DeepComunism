using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
	[CustomEditor(typeof(MapEditorScript))]
	public class MapEditorCustomEditor : Editor
	{
		[SerializeField]
		private MapEditorScript script;

		void OnEnable()
		{
			script = (MapEditorScript)target;
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
			}

			if (GUILayout.Button("Загрузить"))
			{
				script.LoadGrid();
			}
		}

	}
}
