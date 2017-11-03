using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//loads objects that rely on each other in the correct order
public class Initializer : MonoBehaviour {

    public PieceSpawner spawner;
    public ChampionHighlighter highlighter;

    private void Start() {
        highlighter.SubscribeToChamps();
    }
}
