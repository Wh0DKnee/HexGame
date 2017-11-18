using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;
        //TODO: DONT HARDCODE
        public ChampionPosition[] championPositions = new ChampionPosition[]{
            new ChampionPosition("BasicChampion", new HexCoordinates(-3, 3, 0)),
            new ChampionPosition("BasicChampion", new HexCoordinates(-3, 2, 1)),
            new ChampionPosition("BasicChampion", new HexCoordinates(-2, 3, -1))
        };

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }

    [System.Serializable]
    public class ChampionPosition {
        public string ChampionName { get; set; }
        public HexCoordinates HexCoordinates { get; private set; }

        public ChampionPosition(string championName, HexCoordinates coordinates) {
            ChampionName = championName;
            HexCoordinates = coordinates;
        }
    }
}