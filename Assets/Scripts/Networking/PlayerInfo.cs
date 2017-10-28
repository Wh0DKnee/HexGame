using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkingCommonLib {

    [System.Serializable]
    public class PlayerInfo {
        public string nickname;

        public PlayerInfo(string nickname) {
            this.nickname = nickname;
        }
    }
}