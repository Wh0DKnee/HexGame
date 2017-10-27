using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Service;

namespace NetworkingCommonLib {

    [ScsService]
    public interface IServerService {

        void GetEnemyChampions();

        void RequestMove(int championID, HexCoordinates coordinates);

        void RequestAbility(int championID, HexCoordinates target);

    }

}
