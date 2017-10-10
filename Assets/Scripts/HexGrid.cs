using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour {

    private static HexGrid instance = null;

    public GameObject cellPrefab;

    public List<Cell> cells = new List<Cell>();

    public static HexGrid Instance {
        get {
            if(instance == null) {
                instance = (HexGrid)FindObjectOfType(typeof(HexGrid));
            }
            if(instance == null) {
                GameObject go = new GameObject("HexGrid");
                instance = go.AddComponent<HexGrid>();
            }
            return instance;
        }
    }

	// Use this for initialization
	void Awake () {
        if(instance == null) {
            instance = this;
        } else {
            Debug.LogError("more than one hexgrid");
        }
        
	}
    
    public void AddCell(HexCoordinates coordinates) {
        if (Contains(coordinates)) {
            Debug.LogWarning("this hex already exists");
            return;
        }
        GameObject go = (GameObject) Instantiate(cellPrefab, this.transform);
        Cell cell = go.GetComponent<Cell>();
        cell.coordinates = coordinates;
        cell.transform.position = coordinates.ToWorldPosition();
        cells.Add(cell);
        print(cell.ToString());
    }

    public bool Contains(HexCoordinates coordinates) {
        foreach (Cell c in cells) {
            if (c.coordinates == coordinates) {
                return true;
            }
        }
        return false;
    }

    public bool Contains(Cell cell) {
        foreach (Cell c in cells) {
            if(c.coordinates == cell.coordinates) {
                return true;
            }
        }
        return false;
    }
}
