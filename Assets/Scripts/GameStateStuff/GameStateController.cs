using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateController : MonoBehaviour {

    private GameState currentState;
    public IMoveHandler MoveHandler { get; set; }
    public ISkillHandler SkillHandler { get; set; }

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

	public void Initialize() {
        MoveHandler = new NetworkMoveHandler(); //TODO: dont hardcode this

        if (GameInfo.isLeftSide) {
            SetState(new SelectionState(this));
        } else {
            SetState(new EnemyTurnState(this));
        }
	}
	
	void Update () {
        if (currentState != null) {
            currentState.Tick();
        }
	}
}
