using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rename or refactor this
public class Initializer : MonoBehaviour {

    public PieceSpawner spawner;
    public ChampionHighlighter highlighter;

    private void Start() {
        spawner.championsLoaded += OnChampionsLoaded;
    }

    private void OnChampionsLoaded() {
        highlighter.SubscribeToChamps();
    }

    public void ReadyButtonPressed() {
        NetworkSession networkSession = FindObjectOfType<NetworkSession>();
        if (networkSession == null) {
            Debug.LogError("no networksession found");
            return;
        }

        networkSession.Client.TellServerReady();
    }


}
