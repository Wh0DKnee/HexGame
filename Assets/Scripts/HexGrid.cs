using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public void AddCells(List<HexCoordinates> coordinates) {
        foreach (HexCoordinates coord in coordinates) {
            AddCell(coord);
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

    public void AddChamp(Champion champ, HexCoordinates coordinates) {
        Cell cell = GetCell(coordinates);
        if (cell == null) {
            Debug.LogWarning("cant add a piece to a cell that doesnt exist");
            return;
        }
        if (cell.champion != null) {
            Debug.LogWarning("this cell already has a piece");
            return;
        }
        SetCellChampionReferences(cell, champ);
        champ.transform.position = cell.coordinates.ToWorldPosition();
    }

    private void SetCellChampionReferences(Cell cell, Champion champion) {
        cell.champion = champion;
        champion.Stats.Coordinates = cell.coordinates;
    }

    public bool Contains(HexCoordinates coordinates) {
        return GetCell(coordinates) != null;
    }

    public bool Contains(Cell cell) {
        return Contains(cell.coordinates);
    }

    //TODO: cache this!
    public Cell GetCell(HexCoordinates coordinates) {
        foreach (Cell cell in cells) {
            if (cell.coordinates == coordinates) {
                return cell;
            }
        }
        return null;
    }

    public List<Cell> GetCells(List<HexCoordinates> coords) {
        List<Cell> result = new List<Cell>();
        foreach (HexCoordinates c in coords) {
            Cell cell = GetCell(c);
            if(cell == null) {
                Debug.Log("no cell at: " + c.ToString());
                continue;
            }
            result.Add(cell);
        }
        return result;
    }

    public Cell ChampionToCell(Champion champ) {

        if(champ == null) {
            Debug.LogError("null is not a champ");
            return null;
        }

        foreach (Cell cell in cells) {
            if(cell.champion == null) {
                continue;
            }
            if(cell.champion.GetInstanceID() == champ.GetInstanceID()) {
                return cell;
            }
        }
        Debug.LogError("This piece is not associated with a cell");
        return null;
    }

    public Champion GetChamp(HexCoordinates coordinates) {
        return GetCell(coordinates).champion;
    }

    public Champion GetChamp(int championID) {
        Champion result = GetChamps().Where(x => x.Stats.ID == championID).ToList()[0];
        if(result == null) { Debug.LogError("champ with that ID could not be found"); }
        return result;
    }

    public void MoveChamp(Champion champ, HexCoordinates coords) {
        Cell startCell = ChampionToCell(champ);
        if (startCell != null) {
            startCell.champion = null;
        }
        SetCellChampionReferences(GetCell(coords), champ);
    }

    public List<Champion> GetChamps() {
        List<Champion> champs = new List<Champion>();
        foreach (Cell c in cells) {
            if(c.champion != null) {
                champs.Add(c.champion);
            }
        }
        return champs;
    }

    public List<Champion> GetAllyChamps() {
        return GetChamps().Where(x => !x.IsEnemyChamp).ToList();
    }
}
