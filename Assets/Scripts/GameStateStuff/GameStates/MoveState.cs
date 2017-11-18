using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CellListenerGameState {

    public Champion SelectedChamp { get; private set; }

    public event Action OnMoveRequested;

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
        if (MoveValidation.CanChampMove(SelectedChamp, cell, out path)) { // stay in move state if movement range left
            gameStateController.MoveHandler.HandleMove(SelectedChamp, cell.coordinates);
            if(OnMoveRequested != null) { OnMoveRequested(); }
            if (path.Count - 1 < SelectedChamp.RemainingMovementRange) {
                //gameStateController.SetState(new MoveState(gameStateController, SelectedChamp)); //stay in move state if theres movement left
                return;
                        //TODO: we should probably wait for the server to respond before we return,
                        //otherwise, maybe the player can input another movement command before the
                        //remainingMovementRange is adjusted by the server
                        //maybe do this with an additional WaitForServerResponse State?
            }
            gameStateController.SetState(new UseSkillState(gameStateController, SelectedChamp));
        }

    }

    private void SkipMoveState() {
        gameStateController.SetState(new UseSkillState(gameStateController, SelectedChamp));
    }
}
