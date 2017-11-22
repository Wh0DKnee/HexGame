using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateHandler{

    GameState GetNextState(StateChangeParams parameters);
}

public class StateChangeParams {
    public GameStateController gameStateController;
    public Champion champion;

    public StateChangeParams(GameStateController gameStateController, Champion champion) {
        this.gameStateController = gameStateController;
        this.champion = champion;
    }
}
