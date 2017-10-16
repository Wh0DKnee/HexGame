using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour {

    private static HexGrid instance = null; //singleton

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

    public void RemoveCell(HexCoordinates coordinates) {
        if (!Contains(coordinates)) {
            print("cannot remove this cell because it does not exist");
            return;
        }
        Cell cellToRemove = GetCell(coordinates);
        cells.Remove(cellToRemove);
        DestroyImmediate(cellToRemove.gameObject);
    }

    public void AddPiece(Piece piece, HexCoordinates coordinates) {
        Cell cell = GetCell(coordinates);
        if (cell == null) {
            Debug.LogWarning("cant add a piece to a cell that doesnt exist");
            return;
        }
        if (cell.piece != null) {
            Debug.LogWarning("this cell already has a piece");
            return;
        }
        cell.piece = piece;
        piece.transform.position = cell.coordinates.ToWorldPosition();
    }

    public bool Contains(HexCoordinates coordinates) {
        return GetCell(coordinates) != null;
    }

    public bool Contains(Cell cell) {
        return Contains(cell.coordinates);
    }

    public Cell GetCell(HexCoordinates coordinates) {
        foreach (Cell cell in cells) {
            if (cell.coordinates == coordinates) {
                return cell;
            }
        }
        return null;
    }

    //not sure if this method should exist in a well designed program
    public Cell PieceToCell(Piece piece) {

        if(piece == null) {
            Debug.LogError("null is not a piece");
            return null;
        }

        foreach (Cell cell in cells) {
            if(cell.piece == null) {
                continue;
            }
            if(cell.piece.GetInstanceID() == piece.GetInstanceID()) {
                return cell;
            }
        }
        Debug.LogError("This piece is not associated with a cell");
        return null;
    }

    public Piece GetPiece(HexCoordinates coordinates) {
        return GetCell(coordinates).piece;
    }

    public void MovePiece(Piece piece, HexCoordinates coords) {
        Cell startCell = PieceToCell(piece);
        if (startCell != null) {
            startCell.piece = null;
        }

        GetCell(coords).piece = piece;
    }
}
