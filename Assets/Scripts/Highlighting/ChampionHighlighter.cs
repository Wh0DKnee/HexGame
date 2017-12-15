using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//champion highlighting happens regardless of state, so this is not part of the
//highlighting FSM
public class ChampionHighlighter : MonoBehaviour {

    private void Start() {
        PieceSpawner.instance.championsLoaded += OnChampionsLoaded;
    }

    private void OnChampionsLoaded() {
        SubscribeToChamps();
    }

    public void SubscribeToChamps () {
        List<Champion> alliedChamps = HexGrid.Instance.GetAllyChamps();
        foreach (Champion champ in alliedChamps) {
            champ.selected += ChampSelected;
            champ.unselected += ChampUnselected;
        }
	}

    private void ChampSelected(Champion champ) {
        print("highlighting piece, displaying information");
    }

    private void ChampUnselected(Champion champ) {
        print("unhighlighting piece, hiding information");
    }
}
