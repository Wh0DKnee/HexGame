using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndMoveState : GameState {

    private Piece selectedPiece;

    public SelectAndMoveState(GameStateController gsc) : base(gsc) { }

    public override void Tick() {
        
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown += CellMouseDown;
            Piece piece = cell.piece;
            if(piece == null) {
                continue;
            }
            if (!piece.isEnemyPiece) {
                Debug.Log("listening to: " + piece.name);
                piece.mouseDown += PieceMouseDown;
            }
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown -= CellMouseDown;
            Piece piece = cell.piece;
            if (piece == null) {
                continue;
            }
            if (!piece.isEnemyPiece) {
                piece.mouseDown -= PieceMouseDown;
            }
        }
    }

    private void PieceMouseDown(Piece piece) {
        if(piece.FinishedTurn) { return; } //can't select a piece whose turn is finished

        if(selectedPiece == piece) {
            Debug.Log("unselected piece");
            selectedPiece.Unselected();
            selectedPiece = null;
            return;
        }

        if (piece.hasMoved) {
            gameStateController.SetState(new AttackState(gameStateController, piece));
        }
        Debug.Log("selected piece");
        selectedPiece = piece;
        selectedPiece.Selected();
    }

    private void CellMouseDown(Cell cell) {
        if(selectedPiece != null) {
            selectedPiece.Move(cell.coordinates);
            gameStateController.SetState(new AttackState(gameStateController, selectedPiece));
        }
    }
}
