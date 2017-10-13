using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Piece : MonoBehaviour, MouseEvents<Piece> {

    //TODO: create a static event that fires when the slected piece changes
    public static Piece selectedPiece;
    public bool isEnemyPiece;

    public abstract HexCoordinates[] GetMoves();
    public abstract void Move(HexCoordinates coords);

    public event Action<Piece> mouseEnter;
    public event Action<Piece> mouseExit;
    public event Action<Piece> mouseDown;
    public event Action<Piece> mouseOver;

    private void OnMouseEnter() {
        if(mouseEnter != null) mouseEnter(this);
    }

    private void OnMouseExit() {
        if (mouseExit != null) mouseExit(this);
    }

    private void OnMouseDown() {
        if (mouseDown != null) mouseDown(this);
    }

    private void OnMouseOver() {
        if (mouseOver != null) mouseOver(this);
    }

    public Cell GetCell() {
        return HexGrid.Instance.PieceToCell(this);
    }
}
