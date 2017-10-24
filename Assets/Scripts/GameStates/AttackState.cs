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
    }

    private void ReturnToSelectMoveStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    public override void CellMouseDown(Cell clickedCell) {
        if (selectedChamp.TryAttack(clickedCell)) {
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
            if (!champ.hasAttacked) return false;
        }
        return true;
    }
}
