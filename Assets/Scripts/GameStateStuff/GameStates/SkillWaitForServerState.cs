using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWaitForServerState : GameState {

    private Champion champion;

    public SkillWaitForServerState(GameStateController gsc, Champion champion) : base(gsc) {
        this.champion = champion;
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new EmptyHighlighter(CellHighlighter.instance);
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        champion.skillUsed += OnSkillUsed;
    }

    public override void OnStateExit() {
        base.OnStateExit();
        champion.skillUsed -= OnSkillUsed;
    }

    private void OnSkillUsed() {
        StateChangeParams stateChangeParams = new StateChangeParams(gameStateController, champion);
        gameStateController.SetState(champion.SelectedSkill.GetNextState(stateChangeParams));
    }
}
