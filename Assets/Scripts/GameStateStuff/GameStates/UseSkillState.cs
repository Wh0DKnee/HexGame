using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UseSkillState : CellListenerGameState {

    public Champion SelectedChamp { get; private set; }

    public UseSkillState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.SelectedChamp = selectedChamp;
    }

    public override void Tick() {
        ReturnToSelectStateOnEscape();

        SkipUseSkillOnEnter();

        if (Input.GetKeyDown(KeyCode.Q)) { SelectedChamp.SelectedSkill = SelectedChamp.Q; }
        if (Input.GetKeyDown(KeyCode.W)) { SelectedChamp.SelectedSkill = SelectedChamp.W; }
        if (Input.GetKeyDown(KeyCode.E)) { SelectedChamp.SelectedSkill = SelectedChamp.E; }
        if (Input.GetKeyDown(KeyCode.R)) { SelectedChamp.SelectedSkill = SelectedChamp.R; }
    }

    private void ReturnToSelectStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    private void SkipUseSkillOnEnter() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SelectedChamp.SkipUseSkill();
            //TODO: refactor
            if (HaveAllUsedSkill()) {
                gameStateController.SetState(new EnemyTurnState(gameStateController));
            }
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    public override void CellMouseDown(Cell clickedCell) {
        if (!SelectedChamp.CanUseSkill(clickedCell)) {
            return;
        }

        SelectedChamp.UseSkill(clickedCell); //use skillhandler

        if (HaveAllUsedSkill()) {
            gameStateController.SetState(new EnemyTurnState(gameStateController));
        } else {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    private bool HaveAllUsedSkill() {
        List<Champion> allies = HexGrid.Instance.GetAllyChamps();
        foreach (Champion champ in allies) {
            if (!champ.HasUsedSkill) return false;
        }
        return true;
    }
}
