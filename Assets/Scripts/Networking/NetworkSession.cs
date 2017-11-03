using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds the server and/or client object
public class NetworkSession : MonoBehaviour {

    //values set by LobbyContoller
    public Server Server { get; set; }
    public Client Client { get; set; }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartServer() {
        Server.Start();
    }

    private void OnApplicationQuit() {
        if (Server != null) {
            Server.Stop();
        }
    }
}
