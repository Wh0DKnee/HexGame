using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackState : GameState {

    private Champion selectedChamp;

    public AttackState(GameStateController gsc, Champion champ) : base(gsc) {
        selectedChamp = champ;
    }

    public override void Tick() {
        ReturnToSelectMoveStateOnEscape();
    }

    private void ReturnToSelectMoveStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectAndMoveState(gameStateController));
        }
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Champion champ = cell.champion;
            if (champ == null || champ == selectedChamp) {
                continue;
            }
            champ.mouseDown += PieceMouseDown;
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Champion champ = cell.champion;
            if (champ == null || champ == selectedChamp) {
                continue;
            }
            champ.mouseDown -= PieceMouseDown;
        }
    }

    //TODO: also listen to cell mouse down events, check if it has a champ, then proceed as follows
    private void PieceMouseDown(Champion p) {
        if (p == selectedChamp) return;

        if (p.isEnemyChamp /*&& isInRange*/) {
            Debug.Log("Attacking");
            Debug.Log(selectedChamp.name);
            selectedChamp.hasAttacked = true; //TODO: just call selectedChamp.TryAttack(p) here, the flag should be set there instead
            if (HaveAllAttacked()) {
                gameStateController.SetState(new EnemyTurnState(gameStateController));
            } else {
                gameStateController.SetState(new SelectAndMoveState(gameStateController));
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
