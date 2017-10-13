using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelectionState : HighlightState {

    public HighlightSelectionState(CellHighlighter _highlighter) : base(_highlighter) {
    }

    public override void Tick() {
        
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseEnter += CellMouseEnter;
            cell.mouseExit += CellMouseExit;
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseEnter -= CellMouseEnter;
            cell.mouseExit -= CellMouseExit;
        }
    }

    private void CellMouseEnter(Cell cell) {
        highlighter.Highlight(cell);
    }

    private void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(cell);
    }
}
