using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CellListenerGameState {

    public Champion SelectedChamp { get; private set; }

    public MoveState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.SelectedChamp = selectedChamp;
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        if (SelectedChamp.RemainingMovementRange == 0) {
            SkipMoveState();
        }
    }

    public override void CellMouseDown(Cell cell) {
        if (cell.HasAlliedChamp()) {
            gameStateController.SetState(new SelectionState(gameStateController, cell.champion));
            return;
        }

        List<HexCoordinates> path;
        if (MoveValidation.CanChampMove(SelectedChamp, cell, out path)) {
            gameStateController.MoveHandler.HandleMove(SelectedChamp, cell.coordinates);
            gameStateController.SetState(new MoveWaitForServerState(gameStateController, SelectedChamp));
        }

    }

    private void SkipMoveState() {
        gameStateController.SetState(new UseSkillState(gameStateController, SelectedChamp));
    }
}
