/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightStateController : MonoBehaviour {

    public GameStateController gameStateController;
    public CellHighlighter highlighter;

    private StateHighlighter currentState;

    public void SetState(StateHighlighter state) {
        if (state == null) {
            return;
        }
        if (currentState != null) {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }

    private void Start() {
        SetState(new SelectionStateHighlighter(highlighter));
        gameStateController.StateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState) {

        //TODO: find a better solution for this that removes dependecy
        if(gameState.GetType() == typeof(SelectionState)) {
            SetState(new SelectionStateHighlighter(highlighter));
        } else if(gameState.GetType() == typeof(MoveState)) {
            MoveState moveState = gameState as MoveState;
            SetState(new MoveStateHighlighter(highlighter, moveState.SelectedChamp));
        } else if(gameState.GetType() == typeof(SelectSkillState)) {
            SelectSkillState useSkillState = gameState as SelectSkillState;
            SetState(new SingleTargetSkillStateHighlighter(highlighter, useSkillState.SelectedChamp));
        } else {
            SetState(new EmptyHighlighter(highlighter));
        }
    }

}*/
