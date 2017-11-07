using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightMoveState : CellListenerHighlightState {

    private Champion champion;

    public HighlightMoveState(CellHighlighter _highlighter, Champion champion) : base(_highlighter) {
        this.champion = champion;
    }

    public override void CellMouseEnter(Cell cell) {
        if(MoveValidation.CanChampMove(champion, cell)) {
            highlighter.Highlight(cell);
        }
    }

    public override void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(cell);
    }
}
