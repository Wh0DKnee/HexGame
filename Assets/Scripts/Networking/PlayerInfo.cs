﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;
        //TODO: DONT HARDCODE
        public ChampionPosition[] championPositions = new ChampionPosition[]{
            new ChampionPosition("BasicChampion", HexCoordinates.CreateInstance(-2, 2, 0)),
            new ChampionPosition("BasicChampion", HexCoordinates.CreateInstance(-2, 1, 1)),
            new ChampionPosition("BasicChampion", HexCoordinates.CreateInstance(-1, 2, -1))
        };

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }

    [System.Serializable]
    public class ChampionPosition {
        public string ChampionName { get; set; }
        public HexCoordinates Coordinates { get; set; }

        public ChampionPosition(string championName, HexCoordinates coordinates) {
            ChampionName = championName;
            Coordinates = coordinates;
        }
    }
}