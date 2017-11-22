using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetSkillStateHighlighter : CellListenerStateHighlighter {

    private Champion champion;
    private Skill skill;
    private Cell mostRecentCell;

    public SingleTargetSkillStateHighlighter(CellHighlighter _highlighter, Champion champion) : base(_highlighter) {
        this.champion = champion;
        skill = champion.SelectedSkill;
    }

    public override void CellMouseEnter(Cell cell) {
        mostRecentCell = cell;
        HighlightCellIfSkill(cell);
    }

    public override void CellMouseExit(Cell cell) {
        mostRecentCell = null;
        highlighter.UnHighlight(cell);
    }

    private void HighlightCellIfSkill(Cell cell) {
        if (SkillValidation.CanChampUseSkill(champion, champion.SelectedSkill, cell)) {
            highlighter.Highlight(cell);
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        if(mostRecentCell != null) {
            highlighter.UnHighlight(mostRecentCell);
        }
    }
}
