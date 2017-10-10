using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public HexCoordinates coordinates;

    public Sprite defaultSprite;
    public Sprite highlightSprite;

    public override string ToString() {
        return coordinates.ToString();
    }

    private void OnMouseEnter() {
        Highlight();
    }

    private void Highlight() {
        GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    private void OnMouseExit() {
        UnHighlight();
    }

    private void UnHighlight() {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;

    }

    private void OnMouseDown() {
        print(ToString());
    }
}
