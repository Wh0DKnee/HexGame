using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkSessionController : MonoBehaviour {

    public InputField hostNick;
    public InputField connectorNick;
    public InputField IP;
    public InputField connectorPort;

    Server server;
    Client client;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void HostLocal() {
        StartServer();
        CreateLocalClient();
        ConnectClient();
    }

	private void StartServer() {
        server = new Server(100);
        server.Start();
    }

    private void CreateLocalClient() {
        client = new Client("127.0.0.1", 100, hostNick.text);
        
    }

    public void OnConnectButtonPressed() {
        server = null;
        CreateRemoteClient();
        ConnectClient();
    }

    private void CreateRemoteClient() {
        client = new Client(IP.text, int.Parse(connectorPort.text), connectorNick.text);
    }

    private void ConnectClient() {
        if (client.TryConnect()) {
            client.Register();
            //changescene
        }
    }

    private void OnApplicationQuit() {
        if(server != null) {
            server.Stop();
        }
    }
}
