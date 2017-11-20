using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

    protected GameStateController gameStateController;
    protected StateHighlighter stateHighlighter;

    public virtual void Tick() {
        stateHighlighter.Tick();
    }

    public virtual void OnStateEnter() {
        InitializeHighlightState();
        stateHighlighter.OnStateEnter();

    }

    public virtual void OnStateExit() {
        stateHighlighter.OnStateExit();
    }

    public GameState(GameStateController gsc) {
        gameStateController = gsc;
    }

    public abstract void InitializeHighlightState();
}
