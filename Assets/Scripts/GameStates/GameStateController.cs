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
            print("exiting " + currentState.GetType().ToString());
            currentState.OnStateExit();
        }
        currentState = state;
        print("entering " + currentState.GetType().ToString());
        currentState.OnStateEnter();
        if (StateChanged != null) {
            StateChanged(currentState);
        }
    }

	void Start () {
        SetState(new SelectionState(this));
	}
	
	void Update () {
        currentState.Tick();
	}
}
