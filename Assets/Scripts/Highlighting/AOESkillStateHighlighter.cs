using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESkillStateHighlighter : CellListenerStateHighlighter {

    private Champion champion;
    private int radius;

    public AOESkillStateHighlighter(CellHighlighter _highlighter, Champion champion, int radius) : base(_highlighter) {
        this.champion = champion;
    }

    public override void CellMouseEnter(Cell cell) {
        throw new NotImplementedException();
    }

    public override void CellMouseExit(Cell cell) {
        throw new NotImplementedException();
    }
}
