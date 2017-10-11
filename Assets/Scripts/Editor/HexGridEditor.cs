using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(HexGrid))]
public class HexGridEditor : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        HexGrid grid = (HexGrid) target;

        if (GUILayout.Button("Start grid")) {
            grid.AddCell(HexCoordinates.CreateInstance(0, 0));
        }
        if(GUILayout.Button("Delete grid")) {
            grid.cells.Clear();
            foreach (Transform child in grid.transform) {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}
