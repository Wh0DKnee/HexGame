﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Service;

namespace NetworkingCommonLib {

    [ScsService]
    public interface IServiceProxy {

        void GetEnemyChampions();

        void RequestMove(int championID, HexCoordinates coordinates);

        void RequestSkillUse(int userID, SkillEnum skillEnum, HexCoordinates target);

        void RegisterPlayer();

        void GameSceneLoaded();

        void TurnDone();
    }

}
