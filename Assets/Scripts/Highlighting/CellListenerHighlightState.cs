using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellListenerHighlightState : HighlightState {

    public CellListenerHighlightState(CellHighlighter _highlighter) : base(_highlighter) {
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

    public abstract void CellMouseEnter(Cell cell);

    public abstract void CellMouseExit(Cell cell);
}
