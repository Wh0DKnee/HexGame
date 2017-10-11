using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {

    public static Piece selectedPiece;
    public bool isEnemyPiece;

    public abstract HexCoordinates[] GetMoves();
    public abstract void Move(HexCoordinates coords);

    public Cell GetCell() {
        return HexGrid.Instance.PieceToCell(this);
    }

    private void OnMouseDown() {
        if (isEnemyPiece) {
            return;
        }
        if(selectedPiece == this) {
            selectedPiece = null;
            print("unselected");
            return;
        }
        selectedPiece = this;
        print("selected");
    }

}
