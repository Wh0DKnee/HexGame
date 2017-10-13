using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, MouseEvents<Cell> {

    public HexCoordinates coordinates;

    public Sprite defaultSprite;
    public Sprite highlightSprite;

    public Piece piece = null;

    public event Action<Cell> mouseEnter;
    public event Action<Cell> mouseExit;
    public event Action<Cell> mouseDown;
    public event Action<Cell> mouseOver; 

    public override string ToString() {
        return coordinates.ToString();
    }

    private void OnMouseEnter() {
        if (mouseEnter != null) mouseEnter(this);
        //Highlight();
        /*Piece select = Piece.selectedPiece;
        if(select != null) {
            List<HexCoordinates> path = HexMath.DrawLine(select.GetCell().coordinates, coordinates);
            foreach (HexCoordinates coords in path) {
                HexGrid.Instance.GetCell(coords).Highlight();
            }
        } else {
            Highlight();
        }*/
    }

    private void OnMouseExit() {
        if (mouseExit != null) mouseExit(this);
        /*
        Piece select = Piece.selectedPiece;
        if (select != null) {
            List<HexCoordinates> path = HexMath.DrawLine(select.GetCell().coordinates, coordinates);
            foreach (HexCoordinates coords in path) {
                HexGrid.Instance.GetCell(coords).UnHighlight();
            }
        } else {
            UnHighlight();
        }*/
        //UnHighlight();
    }

    private void OnMouseDown() {
        if (mouseDown != null) mouseDown(this);
        print(ToString());
        //refactor this
        Piece.selectedPiece.Move(coordinates);
    }
}
