using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMoveHandler : IMoveHandler {

    public void HandleMove(Champion champion, HexCoordinates coordinates) {
        NetworkSession.instance.Client.TellServerMove(champion.ID, coordinates);
    }

}
