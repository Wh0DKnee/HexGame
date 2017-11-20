using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectSkillState : GameState {

    private Champion selectedChamp;

    public SelectSkillState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.selectedChamp = selectedChamp;
    }

    public SelectSkillState(GameStateController gsc, Champion selectedChamp, KeyCode keyCode) : base(gsc) {
        this.selectedChamp = selectedChamp;
        if (keyCode == KeyCode.Q) { this.selectedChamp.SelectedSkill = this.selectedChamp.Q; }
        if (keyCode == KeyCode.W) { this.selectedChamp.SelectedSkill = this.selectedChamp.W; }
        if (keyCode == KeyCode.E) { this.selectedChamp.SelectedSkill = this.selectedChamp.E; }
        if (keyCode == KeyCode.R) { this.selectedChamp.SelectedSkill = this.selectedChamp.R; }
        gameStateController.SetState(new UseSkillState(gameStateController, this.selectedChamp));
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new EmptyHighlighter(CellHighlighter.instance);
    }

    public override void Tick() {
        ReturnToSelectStateOnEscape();

        if (Input.GetKeyDown(KeyCode.Q)) { selectedChamp.SelectedSkill = selectedChamp.Q; gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp)); }
        if (Input.GetKeyDown(KeyCode.W)) { selectedChamp.SelectedSkill = selectedChamp.W; gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp)); }
        if (Input.GetKeyDown(KeyCode.E)) { selectedChamp.SelectedSkill = selectedChamp.E; gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp)); }
        if (Input.GetKeyDown(KeyCode.R)) { selectedChamp.SelectedSkill = selectedChamp.R; gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp)); }
    }

    private void ReturnToSelectStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }
}
