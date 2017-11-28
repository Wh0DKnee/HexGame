using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillStateHighlighter : CellListenerStateHighlighter {

    private Champion champion;
    private Skill skill;
    List<Cell> currentArea;

    public SkillStateHighlighter(CellHighlighter _highlighter, Champion champion, Skill skill) : base(_highlighter) {
        this.champion = champion;
        this.skill = skill;
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        currentArea = new List<Cell>();
    }

    public override void OnStateExit() {
        base.OnStateExit();
        highlighter.UnHighlight(currentArea);
    }

    public override void CellMouseEnter(Cell cell) {
        if (SkillValidation.CanChampUseSkill(champion, skill, cell)) {
            currentArea = skill.GetAffectedArea(cell);
            highlighter.Highlight(currentArea);
        }
    }

    public override void CellMouseExit(Cell cell) {
        highlighter.UnHighlight(currentArea);
        currentArea.Clear();
    }
}
