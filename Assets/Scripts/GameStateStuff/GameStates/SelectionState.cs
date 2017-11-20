using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : CellListenerGameState {

    private Champion selectedChamp;
    private Champion SelectedChamp {
        get {
            return selectedChamp;
        }
        set {
            if(selectedChamp != null) {
                selectedChamp.Unselected();
            }
            selectedChamp = value;
            selectedChamp.Selected();
            gameStateController.SetState(new MoveState(gameStateController, SelectedChamp));
        }
    }

    public SelectionState(GameStateController gsc) : base(gsc) { }

    public SelectionState(GameStateController gsc, Champion selectedChampion) : base(gsc) {
        SelectedChamp = selectedChampion;
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new SelectionStateHighlighter(CellHighlighter.instance);
    }

    public override void CellMouseDown(Cell cell) {
        TrySelectChamp(cell);
    }

    private void TrySelectChamp(Cell cell) {
        if (cell.HasAlliedChamp()) {
            Champion clickedChamp = cell.champion;
            if (!clickedChamp.FinishedTurn) {
                SelectedChamp = cell.champion;
            }
        }
    }
}
