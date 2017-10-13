using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightStateController : MonoBehaviour {

    public GameStateController gameStateController;

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
        gameStateController.StateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState) {

    }

}
