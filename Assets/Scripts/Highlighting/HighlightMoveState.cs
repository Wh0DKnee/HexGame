using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightMoveState : CellListenerHighlightState {

    private Champion champion;
    private List<Cell> path;

    public HighlightMoveState(CellHighlighter _highlighter, Champion champion) : base(_highlighter) {
        this.champion = champion;
        path = new List<Cell>();
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        ShowPossibleMoves();
    }

    public override void OnStateExit() {
        base.OnStateExit();
        HidePossibleMoves();
    }

    private void ShowPossibleMoves() {
        foreach (Cell cell in HexGrid.Instance.cells) {
            if(MoveValidation.CanChampMove(champion, cell)) {
                highlighter.SetDefaultSprite(cell, highlighter.allMoveHighlightSprite);
            }
        }
        highlighter.UnHighlightAll();
    }

    public override void CellMouseEnter(Cell cell) {
        if(MoveValidation.CanChampMove(champion, cell, out path)) {
            HighlightPath();
        }
    }

    public override void CellMouseExit(Cell cell) {
        UnHighlightPath();
    }

    private void HidePossibleMoves() {
        highlighter.ResetDefaultSprites();
        highlighter.UnHighlightAll();
    }

    private void HighlightPath() {
        highlighter.Highlight(path);
    }

    private void UnHighlightPath() {
        highlighter.UnHighlight(path);
    }
}
