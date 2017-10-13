using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Piece : MonoBehaviour, MouseEvents<Piece> {

    public static Piece selectedPiece;
    public bool isEnemyPiece;

    public abstract HexCoordinates[] GetMoves();
    public abstract void Move(HexCoordinates coords);

    public event Action<Piece> mouseEnter;
    public event Action<Piece> mouseExit;
    public event Action<Piece> mouseDown;
    public event Action<Piece> mouseOver;

    private void OnMouseEnter() {
        mouseEnter(this);
    }

    private void OnMouseExit() {
        mouseExit(this);
    }

    private void OnMouseDown() {
        mouseDown(this);
    }

    private void OnMouseOver() {
        mouseOver(this);
    }

    public Cell GetCell() {
        return HexGrid.Instance.PieceToCell(this);
    }
}
