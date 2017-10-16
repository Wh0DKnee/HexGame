using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//champion highlighting happens regardless of state, so this is not part of the
//highlighting FSM
public class ChampionHighlighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Cell cell in HexGrid.Instance.cells) {
            Piece piece = cell.piece;
            if (piece == null) {
                continue;
            }
            if (!piece.isEnemyPiece) {
                Debug.Log("listening to: " + piece.name);
                piece.selected += PieceSelected;
                piece.unselected += PieceUnselected;
            }
        }
	}

    private void PieceSelected(Piece piece) {
        print("highlighting piece, displaying information");
    }

    private void PieceUnselected(Piece piece) {
        print("unhighlighting piece, hiding information");
    }
}
