using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHighlighter : MonoBehaviour {
    public Sprite defaultSprite;
    public Sprite highlightSprite;
    public Sprite allMoveHighlightSprite;

    private Sprite currentHighlightSprite;

    private Dictionary<Cell, Sprite> cellsDefaultSprite;

    private void Start() {
        cellsDefaultSprite = new Dictionary<Cell, Sprite>();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cellsDefaultSprite.Add(cell, defaultSprite);
        }
        currentHighlightSprite = highlightSprite;
    }

    public void SetHighlightSprite(Sprite sprite) {
        currentHighlightSprite = sprite;
    }

    public void SetDefaultSprite(Cell cell, Sprite sprite) {
        cellsDefaultSprite[cell] = sprite;
    }

    //TODO: check if cell has champion and if so, highlight champion instead
    public void Highlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = currentHighlightSprite;
    }

    public void UnHighlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = cellsDefaultSprite[cell];
    }

    public void UnHighlightAll() {
        foreach (Cell cell in HexGrid.Instance.cells) {
            UnHighlight(cell);
        }
    }

    public void ResetDefaultSprites() {
        List<Cell> keys = new List<Cell>(cellsDefaultSprite.Keys);
        foreach (Cell cell in keys) {
            cellsDefaultSprite[cell] = defaultSprite;
        }
    }

    public void Highlight(HexCoordinates coords) {
        Highlight(HexGrid.Instance.GetCell(coords));
    }

    public void UnHighlight(HexCoordinates coords) {
        UnHighlight(HexGrid.Instance.GetCell(coords));
    }

    public void Highlight(List<Cell> cells) {
        foreach (Cell cell in cells) {
            Highlight(cell);
        }
    }

    public void UnHighlight(List<Cell> cells) {
        foreach (Cell cell in cells) {
            UnHighlight(cell);
        }
    }

    public void Highlight(List<HexCoordinates> coords) {
        foreach (HexCoordinates hc in coords) {
            Highlight(hc);
        }
    }

    public void UnHighlight(List<HexCoordinates> coords) {
        foreach (HexCoordinates hc in coords) {
            UnHighlight(hc);
        }
    }
}

