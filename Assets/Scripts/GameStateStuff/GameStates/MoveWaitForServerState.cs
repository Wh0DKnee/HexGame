using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaitForServerState : GameState {

    private Champion champion;

    public MoveWaitForServerState(GameStateController gsc, Champion champion) : base(gsc) {
        this.champion = champion;
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new EmptyHighlighter(CellHighlighter.instance);
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        champion.moved += OnMoved;
    }

    public override void OnStateExit() {
        base.OnStateExit();
        champion.moved -= OnMoved;
    }

    private void OnMoved() {
        if (champion.RemainingMovementRange > 0) {
            gameStateController.SetState(new MoveState(gameStateController, champion));
        } else {
            gameStateController.SetState(new SelectSkillState(gameStateController, champion));
        }
    }


}
