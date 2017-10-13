using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHighlighter : MonoBehaviour {

    public static CellHighlighter instance;

    public Sprite defaultSprite;
    public Sprite highlightSprite;

    void Awake() {
        if (instance != null) {
            Debug.LogError("more than one singleton");
        } else {
            instance = this;
        }
    }

    private void Start() {
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown += MouseDown;
            cell.mouseEnter += MouseEnter;
            cell.mouseExit += MouseExit;
        }
    }

    private void MouseDown(Cell cell) {

    }

    private void MouseEnter(Cell cell) {
        Highlight(cell);
    }

    private void MouseExit(Cell cell) {
        UnHighlight(cell);
    }

    public void Highlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    public void UnHighlight(Cell cell) {
        cell.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
