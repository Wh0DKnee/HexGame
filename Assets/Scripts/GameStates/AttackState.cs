using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GameState {

    private Piece selectedPiece;

    public AttackState(GameStateController gsc, Piece piece) : base(gsc) {

    }

    public override void Tick() {
        if (Input.GetKeyDown(KeyCode.Escape)) { //when the user wants to leave attack mode, he presses escape to go back to selection mode
            gameStateController.SetState(new SelectAndMoveState(gameStateController));
        }
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Piece p = cell.piece;
            if (p == null || p == selectedPiece) {
                continue;
            }
            p.mouseDown += PieceMouseDown;
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Piece p = cell.piece;
            if (p == null || p == selectedPiece) {
                continue;
            }
            p.mouseDown -= PieceMouseDown;
        }
    }

    private void PieceMouseDown(Piece p) {
        if (p == selectedPiece) return;

        if (p.isEnemyPiece /*&& isInRange*/) {
            Debug.Log("Attacking");
            gameStateController.SetState(new SelectAndMoveState(gameStateController)); //check if all pieces finished their turns
        }
    }
}
