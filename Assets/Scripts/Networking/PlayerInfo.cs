using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;
        //champion list or smth

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }
}