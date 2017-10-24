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
    public abstract bool TryAttack(Cell target);
    
    public event Action<Champion> selected;
    public event Action<Champion> unselected;

    public void Selected() {
        print("selected!");
        if (selected != null) selected(this);
    }

    public void Unselected() {
        print("unselected!");
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
