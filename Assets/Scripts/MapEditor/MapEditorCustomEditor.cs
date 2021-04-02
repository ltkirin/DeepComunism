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
			if (GUILayout.Button("������������� �����"))
			{
				script.GeneraTeEmptyGrid();
			}	
			if (GUILayout.Button("�������� �����"))
			{
				script.ClearGrid();
			}
			if (GUILayout.Button("���������"))
			{
				script.SaveMap();
			}

			if (GUILayout.Button("���������"))
			{
				script.LoadGrid();
			}
		}

	}
}
