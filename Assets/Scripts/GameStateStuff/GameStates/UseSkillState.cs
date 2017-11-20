using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkillState : CellListenerGameState {

    private Champion selectedChampion;

    public UseSkillState(GameStateController gsc, Champion champion) : base(gsc) {
        this.selectedChampion = champion;
    }

    public override void Tick() {
        SkipUseSkillOnEnter();

        //refactor all of these events into seperate class
        if (Input.GetKeyDown(KeyCode.Q)) { gameStateController.SetState(new SelectSkillState(gameStateController, selectedChampion, KeyCode.Q)); }
        if (Input.GetKeyDown(KeyCode.W)) { gameStateController.SetState(new SelectSkillState(gameStateController, selectedChampion, KeyCode.W)); }
        if (Input.GetKeyDown(KeyCode.E)) { gameStateController.SetState(new SelectSkillState(gameStateController, selectedChampion, KeyCode.E)); }
        if (Input.GetKeyDown(KeyCode.R)) { gameStateController.SetState(new SelectSkillState(gameStateController, selectedChampion, KeyCode.R)); }
    }

    public override void InitializeHighlightState() {
        stateHighlighter = selectedChampion.SelectedSkill.GetHighlighter();
    }

    public override void CellMouseDown(Cell clickedCell) {
        if (!selectedChampion.CanUseSkill(clickedCell)) {
            Debug.Log("Can't use spell on this cell");
            return;
        }

        gameStateController.SkillHandler.HandleSkill(selectedChampion, selectedChampion.SelectedSkill, clickedCell.coordinates);

        if (HaveAllUsedSkill()) {
            gameStateController.SetState(new EnemyTurnState(gameStateController));
        } else {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    private void SkipUseSkillOnEnter() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            selectedChampion.SkipUseSkill();
            //TODO: refactor
            if (HaveAllUsedSkill()) {
                gameStateController.SetState(new EnemyTurnState(gameStateController));
                return;
            }
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
