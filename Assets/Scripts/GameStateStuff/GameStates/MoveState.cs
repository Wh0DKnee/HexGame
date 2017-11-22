using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CellListenerGameState {

    public Champion SelectedChamp { get; private set; }

    public MoveState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.SelectedChamp = selectedChamp;
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new MoveStateHighlighter(CellHighlighter.instance, SelectedChamp);
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

        if (MoveValidation.CanChampMove(SelectedChamp, cell)) {
            //IMoveHandler moveHandler = MoveHandlerFactory.GetMoveHandler();
            gameStateController.MoveHandler.HandleMove(SelectedChamp, cell.coordinates);
            StateChangeParams stateChangeParams = new StateChangeParams(gameStateController, SelectedChamp);
            gameStateController.SetState(gameStateController.MoveHandler.GetNextState(stateChangeParams));
        }

    }

    private void SkipMoveState() {
        gameStateController.SetState(new SkillState(gameStateController, SelectedChamp));
    }
}
