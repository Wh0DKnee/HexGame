using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour {

    public GameObject clientControllerPrefab;
    public GameObject serverPrefab;

    public InputField hostNick;
    public InputField connectorNick;
    public InputField IP;
    public InputField connectorPort;

    public void HostLocal() {
        StartServer();
        ConnectToLocalServer();
    }

	private void StartServer() {
        GameObject serverGO = Instantiate(serverPrefab);
        Server server = serverGO.GetComponent<Server>();
        server.StartServer();
    }

    private void ConnectToLocalServer() {
        GameObject clientGO = Instantiate(clientControllerPrefab);
        Client clientController = clientGO.GetComponent<Client>();
        clientController.Initialize("127.0.0.1", 100, hostNick.text);
    }

    public void ConnectToRemoteServer() {
        GameObject clientGO = Instantiate(clientControllerPrefab);
        Client clientController = clientGO.GetComponent<Client>();
        clientController.Initialize(IP.text, int.Parse(connectorPort.text), connectorNick.text);
    }
}
