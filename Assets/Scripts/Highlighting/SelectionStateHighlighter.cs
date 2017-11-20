using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionStateHighlighter : CellListenerStateHighlighter {

    public SelectionStateHighlighter(CellHighlighter _highlighter) : base(_highlighter) {
    }

    public override void CellMouseEnter(Cell cell) {
        highlighter.Highlight(cell);
    }

    public override void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(cell);
    }
}
