using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : GameState {

    public override void Tick() {
        throw new NotImplementedException();
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Piece piece = cell.piece;
            if (!piece.isEnemyPiece) {
                piece.mouseDown += PieceMouseDown;
            }
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            Piece piece = cell.piece;
            if (!piece.isEnemyPiece) {
                piece.mouseDown -= PieceMouseDown;
            }
        }
    }

    private void PieceMouseDown(Piece piece) {
        if(Piece.selectedPiece == piece) {
            Piece.selectedPiece = null;
            return;
        }
        Piece.selectedPiece = piece;
    }
}
