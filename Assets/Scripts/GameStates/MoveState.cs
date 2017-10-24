using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CellListenerGameState {

    Champion selectedChamp;

    public MoveState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.selectedChamp = selectedChamp;
        if (selectedChamp.hasMoved) {
            SkipMoveState();
        }
    }

    public override void CellMouseDown(Cell cell) {
        if (cell.HasAlliedChamp()) {
            gameStateController.SetState(new SelectionState(gameStateController, cell.champion));
        } else {
            if (TargetReachable(cell)) {
                selectedChamp.Move(cell.coordinates);
                gameStateController.SetState(new AttackState(gameStateController, selectedChamp));
            }
        }
    }

    private void SkipMoveState() {
        gameStateController.SetState(new AttackState(gameStateController, selectedChamp));
    }

    //TODO: decide if this logic belongs in the champion class instead
    private bool TargetReachable(Cell target) {
        if (target.HasChamp()) { return false; }

        HexCoordinates[] moves = selectedChamp.GetMoves();
        bool reachable = false;
        foreach (HexCoordinates move in moves) {
                if(selectedChamp.GetCell().coordinates + move == target.coordinates) {
                reachable = true;
            }
        }
        return reachable;
    }
}
