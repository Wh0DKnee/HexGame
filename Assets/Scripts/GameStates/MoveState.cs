using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CellListenerGameState {

    Champion selectedChamp;

    public MoveState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.selectedChamp = selectedChamp;
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        if (selectedChamp.HasMoved) {
            SkipMoveState();
        }
    }

    public override void CellMouseDown(Cell cell) {
        if (cell.HasAlliedChamp()) {
            gameStateController.SetState(new SelectionState(gameStateController, cell.champion));
        } else {
            if (TargetReachable(cell)) {
                selectedChamp.Move(cell.coordinates);
                //TODO: use the following line instead. To make it work, we need to refactor the HexCoordinates class
                //so that it is serializable. This means not inheriting from ScriptableObject. This, in turn, means that
                //or editor scripts will no longer work. We should instead just store the maps in an XML file and load them as we open
                //the game scene.
                //gameStateController.MoveHandler.HandleMove(selectedChamp, cell.coordinates);
                gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp));
            }
        }
    }

    private void SkipMoveState() {
        gameStateController.SetState(new UseSkillState(gameStateController, selectedChamp));
    }

    //TODO: decide if this logic belongs in the champion class instead
    private bool TargetReachable(Cell target) {
        if (target.HasChamp()) { return false; }

        HexCoordinates[] moves = selectedChamp.GetMoves();
        bool reachable = false;
        foreach (HexCoordinates move in moves) {
                if(selectedChamp.GetCell().coordinates + move == target.coordinates) {
                reachable = true;
            }
        }
        return reachable;
    }
}
