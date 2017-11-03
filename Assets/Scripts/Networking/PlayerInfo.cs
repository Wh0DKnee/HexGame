using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;
        //TODO: DONT HARDCODE
        public ChampionPosition[] championPositions = new ChampionPosition[]{
            new ChampionPosition("BasicChampion", -2, 2, 0),
            new ChampionPosition("BasicChampion", -2, 1, 1),
            new ChampionPosition("BasicChampion", -1, 2, -1)
        };

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }

    [System.Serializable]
    public class ChampionPosition {
        public string ChampionName { get; set; }
        //The reason that we are currently not just using HexCoordinates is because they cant be serialized I think.
        //TODO: This is bad and should be changed. 
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public ChampionPosition(string championName, int x, int y, int z) {
            ChampionName = championName;
            X = x;
            Y = y;
            Z = z;
        }
    }
}