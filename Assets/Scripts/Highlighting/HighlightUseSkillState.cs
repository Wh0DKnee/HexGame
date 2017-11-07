using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightUseSkillState : CellListenerHighlightState {

    private Champion champion;

    public HighlightUseSkillState(CellHighlighter _highlighter, Champion champion) : base(_highlighter) {
        this.champion = champion;
    }

    public override void CellMouseEnter(Cell cell) {
        if(champion.SelectedSkill == null) { return; }

        if (SkillValidation.CanChampUseSkill(champion, champion.SelectedSkill, cell)) {
            highlighter.Highlight(cell);
        }
    }

    public override void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(cell);
    }
}
