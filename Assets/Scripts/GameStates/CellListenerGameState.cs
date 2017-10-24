using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellListenerGameState : GameState {

    public CellListenerGameState(GameStateController gsc) : base(gsc) {
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown += CellMouseDown;
        }
    }

    public override void OnStateExit() {
        base.OnStateExit();
        foreach (Cell cell in HexGrid.Instance.cells) {
            cell.mouseDown -= CellMouseDown;
        }
    }

    public abstract void CellMouseDown(Cell cell);
}
