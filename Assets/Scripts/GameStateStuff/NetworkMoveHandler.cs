using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMoveHandler : IMoveHandler {

    public GameState GetNextState(StateChangeParams parameters) {
        return new MoveWaitForServerState(parameters.gameStateController, parameters.champion);
    }

    public void HandleMove(Champion champion, HexCoordinates coordinates) {
        NetworkSession.instance.Client.TellServerMove(champion.ID, coordinates);
    }

}
