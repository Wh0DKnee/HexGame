using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelectionState : CellListenerHighlightState {

    public HighlightSelectionState(CellHighlighter _highlighter) : base(_highlighter) {
    }

    public override void CellMouseEnter(Cell cell) {
        highlighter.Highlight(cell);
    }

    public override void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(cell);
    }
}
