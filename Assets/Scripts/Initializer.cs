using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour {

    public GameObject button;

    //TODO automatically call TellServerReady() when scene is finished loading
    public void ReadyButtonPressed() {
        NetworkSession networkSession = FindObjectOfType<NetworkSession>();
        if (networkSession == null) {
            Debug.LogError("no networksession found");
            return;
        }

        networkSession.Client.TellServerReady();
        Destroy(button);
    }


}
