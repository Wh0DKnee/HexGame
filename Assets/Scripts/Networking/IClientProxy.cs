using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Client;

namespace NetworkingCommonLib {

    public interface IClientProxy {

        PlayerInfo GetClientInfo();

        void MoveChampion(int championID, HexCoordinates coordinates);

        void UseAbility(int championID, HexCoordinates targetCellCoordinates);

        void ChangeScene(string sceneName);

    }
}
