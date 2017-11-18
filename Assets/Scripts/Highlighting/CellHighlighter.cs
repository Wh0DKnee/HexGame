using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHighlighter : MonoBehaviour {
    public Sprite defaultSprite;
    public Sprite highlightSprite;

    //TODO: check if cell has champion and if so, highlight champion instead
    public void Highlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    public void UnHighlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    public void Highlight(HexCoordinates coords) {
        Highlight(HexGrid.Instance.GetCell(coords));
    }

    public void UnHighlight(HexCoordinates coords) {
        UnHighlight(HexGrid.Instance.GetCell(coords));
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
