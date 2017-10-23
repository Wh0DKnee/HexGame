using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//champion highlighting happens regardless of state, so this is not part of the
//highlighting FSM
public class ChampionHighlighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Cell cell in HexGrid.Instance.cells) {
            Champion champ = cell.champion;
            if (champ == null) {
                continue;
            }
            if (!champ.isEnemyChamp) {
                Debug.Log("listening to: " + champ.name);
                champ.selected += ChampSelected;
                champ.unselected += ChampUnselected;
            }
        }
	}

    private void ChampSelected(Champion champ) {
        print("highlighting piece, displaying information");
    }

    private void ChampUnselected(Champion champ) {
        print("unhighlighting piece, hiding information");
    }
}
