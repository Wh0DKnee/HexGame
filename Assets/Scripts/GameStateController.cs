using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateController : MonoBehaviour {

    private GameState currentState;

    public event Action<GameState> StateChanged;

    public void SetState(GameState state) {
        if(state == null) {
            return;
        }
        if(currentState != null) {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
        if (StateChanged != null) {
            StateChanged(currentState);
        }
    }

	void Start () {
        SetState(new SelectionState());
	}
	
	// Update is called once per frame
	void Update () {
        currentState.Tick();
	}
}
