using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndMoveState : GameState {

    private Champion selectedChamp;

    public SelectAndMoveState(GameStateController gsc) : base(gsc) { }

    public override void Tick() {
        
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown += CellMouseDown;
            Champion champ = cell.champion;
            if(champ == null) {
                continue;
            }
            if (!champ.isEnemyChamp) {
                Debug.Log("listening to: " + champ.name);
                champ.mouseDown += PieceMouseDown;
            }
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown -= CellMouseDown;
            Champion champ = cell.champion;
            if (champ == null) {
                continue;
            }
            if (!champ.isEnemyChamp) {
                champ.mouseDown -= PieceMouseDown;
            }
        }
    }

    private void PieceMouseDown(Champion champ) {
        if(champ.FinishedTurn || champ.isEnemyChamp) { return; }

        if(selectedChamp == champ) {
            Debug.Log("unselected piece");
            selectedChamp.Unselected();
            selectedChamp = null;
            return;
        }

        if (champ.hasMoved) {
            gameStateController.SetState(new AttackState(gameStateController, champ));
        }
        Debug.Log("selected piece");
        selectedChamp = champ;
        selectedChamp.Selected();
    }

    private void CellMouseDown(Cell cell) {
        if(selectedChamp != null) {
            selectedChamp.Move(cell.coordinates);
            gameStateController.SetState(new AttackState(gameStateController, selectedChamp));
        }
    }
}
