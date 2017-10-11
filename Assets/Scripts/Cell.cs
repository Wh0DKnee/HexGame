using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IHighlightable {

    public HexCoordinates coordinates;

    public Sprite defaultSprite;
    public Sprite highlightSprite;

    public Piece piece = null;

    public override string ToString() {
        return coordinates.ToString();
    }

    private void OnMouseEnter() {
        Highlight();
    }

    public void Highlight() {
        GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    private void OnMouseExit() {
        UnHighlight();
    }

    public void UnHighlight() {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;

    }

    private void OnMouseDown() {
        print(ToString());
        Piece.selectedPiece.Move(coordinates);
    }
}
