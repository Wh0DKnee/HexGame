using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Piece : MonoBehaviour, MouseEvents<Piece> {
   
    public bool isEnemyPiece;
    public bool hasMoved = false;
    public bool hasAttacked = false;
    public bool FinishedTurn {
        get {
            return hasMoved && hasAttacked;
        }
    }

    public abstract HexCoordinates[] GetMoves();

    public event Action<Piece> mouseEnter;
    public event Action<Piece> mouseExit;
    public event Action<Piece> mouseDown;
    public event Action<Piece> mouseOver;

    public event Action<Piece> selected;
    public event Action<Piece> unselected;

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

    public void Selected() {
        if (selected != null) selected(this);
    }

    public void Unselected() {
        if (unselected != null) unselected(this);
    }

    public virtual void Move(HexCoordinates coords) {
        hasMoved = true;
        this.gameObject.transform.position = coords.ToWorldPosition();
        HexGrid.Instance.MovePiece(this, coords);
    }
}
