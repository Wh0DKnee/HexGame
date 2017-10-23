using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Champion : MonoBehaviour{
   
    public bool isEnemyChamp;
    public bool hasMoved = false;
    public bool hasAttacked = false;
    public bool FinishedTurn {
        get {
            return hasMoved && hasAttacked;
        }
    }

    public abstract HexCoordinates[] GetMoves();
    
    public event Action<Champion> selected;
    public event Action<Champion> unselected;

    public void Selected() {
        if (selected != null) selected(this);
    }

    public void Unselected() {
        if (unselected != null) unselected(this);
    }

    public Cell GetCell() {
        return HexGrid.Instance.ChampionToCell(this);
    }

    public virtual void Move(HexCoordinates coords) {
        hasMoved = true;
        this.gameObject.transform.position = coords.ToWorldPosition();
        HexGrid.Instance.MoveChamp(this, coords);
    }
}
