using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightStateController : MonoBehaviour {

    public GameStateController gameStateController;
    public CellHighlighter highlighter;

    private HighlightState currentState;

    public void SetState(HighlightState state) {
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
        SetState(new HighlightSelectionState(highlighter));
        gameStateController.StateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState) {

        //TODO: find a better solution for this that removes dependecy
        if(gameState.GetType() == typeof(SelectionState)) {
            SetState(new HighlightSelectionState(highlighter));
        } else if(gameState.GetType() == typeof(MoveState)) {
            MoveState moveState = gameState as MoveState;
            SetState(new HighlightMoveState(highlighter, moveState.SelectedChamp));
        } else if(gameState.GetType() == typeof(UseSkillState)) {
            UseSkillState useSkillState = gameState as UseSkillState;
            SetState(new HighlightUseSkillState(highlighter, useSkillState.SelectedChamp));
        } else {
            SetState(new HighlightWaitState(highlighter));
        }
    }

}
