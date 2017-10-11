using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Cell))]
public class CellEditor : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Cell cell = (Cell) target;

        if(GUILayout.Button("Add east")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 0));
        }
        if (GUILayout.Button("Add northeast")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 1));
        }
        if (GUILayout.Button("Add northwest")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 2));
        }
        if (GUILayout.Button("Add west")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 3));
        }
        if (GUILayout.Button("Add southwest")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 4));
        }
        if (GUILayout.Button("Add southeast")) {
            HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, 5));
        }
        if(GUILayout.Button("Add all neighbors")) {
            for (int i = 0; i < 6; i++) {
                HexGrid.Instance.AddCell(HexMath.HexNeighbor(cell.coordinates, i));
            }
        }
        if (GUILayout.Button("Remove")) {
            HexGrid.Instance.RemoveCell(cell.coordinates);
        }
    }
}
