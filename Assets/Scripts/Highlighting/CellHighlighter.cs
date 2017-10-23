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
}
