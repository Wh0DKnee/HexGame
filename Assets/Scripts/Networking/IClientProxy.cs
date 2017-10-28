using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Client;

namespace NetworkingCommonLib {

    public interface IClientProxy {

        void MoveChampion(int championID, HexCoordinates coordinates);

        void UseAbility(int championID, HexCoordinates targetCellCoordinates);
        
    }
}
