using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, MouseEvents<Cell> {

    public HexCoordinates coordinates;

    public Champion champion = null;

    public event Action<Cell> mouseEnter;
    public event Action<Cell> mouseExit;
    public event Action<Cell> mouseDown;
    public event Action<Cell> mouseOver; 

    public override string ToString() {
        return coordinates.ToString();
    }

    private void OnMouseEnter() {
        if (mouseEnter != null) mouseEnter(this);
    }

    private void OnMouseExit() {
        if (mouseExit != null) mouseExit(this);
    }

    private void OnMouseDown() {
        if (mouseDown != null) mouseDown(this);
    }

    public bool HasChamp() {
        return champion != null;
    }

    public bool HasEnemyChamp() {
        if (!HasChamp()) { return false; }
        return champion.IsEnemyChamp;
    }

    public bool HasAlliedChamp() {
        if(!HasChamp()) { return false; }
        return !champion.IsEnemyChamp;
    }
}
