using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackState : CellListenerGameState {

    private Champion selectedChamp;

    public AttackState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.selectedChamp = selectedChamp;
    }

    public override void Tick() {
        ReturnToSelectMoveStateOnEscape();
        if (Input.GetKeyDown(KeyCode.Q)) { selectedChamp.SelectedSkill = selectedChamp.Q; }
        if (Input.GetKeyDown(KeyCode.W)) { selectedChamp.SelectedSkill = selectedChamp.W; }
        if (Input.GetKeyDown(KeyCode.E)) { selectedChamp.SelectedSkill = selectedChamp.E; }
        if (Input.GetKeyDown(KeyCode.R)) { selectedChamp.SelectedSkill = selectedChamp.R; }
    }

    private void ReturnToSelectMoveStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    public override void CellMouseDown(Cell clickedCell) {
        Debug.Log("trying to use skill");
        if (selectedChamp.TryUseSkill(clickedCell)) {
            if (HaveAllAttacked()) {
                gameStateController.SetState(new EnemyTurnState(gameStateController));
            } else {
                gameStateController.SetState(new SelectionState(gameStateController));
            }
        }
    }

    private bool HaveAllAttacked() {
        List<Champion> allies = HexGrid.Instance.GetAllyChamps();
        foreach (Champion champ in allies) {
            if (!champ.HasAttacked) return false;
        }
        return true;
    }
}
