using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds the server and/or client object
public class NetworkSession : MonoBehaviour {

    public static NetworkSession instance;

    //values set by LobbyContoller
    public Server Server { get; set; }
    public Client Client { get; set; }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if(instance != null) {
            print("more than one network session object");
            return;
        }
        instance = this;
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
