using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;
        //TODO: DONT HARDCODE
        public string[] championNames = new string[]{"BasicChampion", "BasicChampion", "BasicChampion"};

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }
}