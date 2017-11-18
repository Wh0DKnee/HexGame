using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightMoveState : CellListenerHighlightState {

    private Champion champion;
    private List<HexCoordinates> path;
    private MoveState moveState;

    public HighlightMoveState(CellHighlighter _highlighter, Champion champion, MoveState moveState) : base(_highlighter) {
        this.champion = champion;
        path = new List<HexCoordinates>();
        this.moveState = moveState;
        this.moveState.OnMoveRequested += OnMoveRequested;
        ShowPossibleMoves();
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

    private void OnMoveRequested() {
        UnHighlightPath();
        HidePossibleMoves();
    }

    private void HidePossibleMoves() {
        highlighter.ResetDefaultSprites();
        highlighter.UnHighlightAll();
    }

    public override void UnsubscribeAllEvents() {
        base.UnsubscribeAllEvents();
        moveState.OnMoveRequested -= OnMoveRequested;
    }

    private void HighlightPath() {
        highlighter.Highlight(path);
    }

    private void UnHighlightPath() {
        highlighter.UnHighlight(path);
    }
}
