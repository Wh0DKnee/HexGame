using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using NetworkingCommonLib;

public class ClientProxyImpl : IClientProxy {

    public PlayerInfo PlayerInfo { get; private set; }

    public ClientProxyImpl(PlayerInfo info) {
        PlayerInfo = info;
    }

    public void MoveChampion(int championID, HexCoordinates coordinates) {
        Debug.Log("server called MoveChampion");
    }

    public void UseAbility(int championID, HexCoordinates targetCellCoordinates) {
        Debug.Log("server called UseAbility");
    }

}
