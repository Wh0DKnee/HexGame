using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightUseSkillState : CellListenerHighlightState {

    private Champion champion;
    private Skill skill;
    private Cell mostRecentCell;

    public HighlightUseSkillState(CellHighlighter _highlighter, Champion champion) : base(_highlighter) {
        this.champion = champion;
        skill = champion.SelectedSkill;
        champion.selectedSkillChanged += OnSelectedSkillChanged;
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
        if (champion.SelectedSkill == null) { return; }
        Debug.Log("cell mouse enter event");

        if (SkillValidation.CanChampUseSkill(champion, champion.SelectedSkill, cell)) {
            highlighter.Highlight(cell);
        }
    }

    private void OnSelectedSkillChanged() {
        skill = champion.SelectedSkill;
        if (mostRecentCell != null) {
            HighlightCellIfSkill(mostRecentCell);
        }
    }
}
