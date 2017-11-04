using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: remove this
public class Initializer : MonoBehaviour {

    //TODO automatically call TellServerReady() when scene is finished loading
    public void ReadyButtonPressed() {
        NetworkSession networkSession = FindObjectOfType<NetworkSession>();
        if (networkSession == null) {
            Debug.LogError("no networksession found");
            return;
        }

        networkSession.Client.TellServerReady();
    }


}
