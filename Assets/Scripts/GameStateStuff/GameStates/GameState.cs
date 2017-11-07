using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

    protected GameStateController gameStateController;

    public virtual void Tick() {}

    public virtual void OnStateEnter() {

    }

    public virtual void OnStateExit() {

    }

    public GameState(GameStateController gsc) {
        gameStateController = gsc;
    }
}
