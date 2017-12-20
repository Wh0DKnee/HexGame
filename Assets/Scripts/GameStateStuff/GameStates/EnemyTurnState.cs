using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : GameState {

    public EnemyTurnState(GameStateController gsc) : base(gsc) {}

    public override void Tick() {
    }

    public override void InitializeHighlightState() {
        stateHighlighter = new EmptyHighlighter(CellHighlighter.instance);
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        NetworkSession.instance.Client.TellServerTurnDone();
        NetworkSession.instance.Client.ClientProxy.EnemyTurnEnd += OnEnemyTurnEnd;

        foreach (Champion enemy in HexGrid.Instance.GetAllyChamps()) {
            enemy.NewTurnReset();                                               // currently we do this locally for enemies and for allies
                                                                                // it would probably be cleaner to network this instead.
        }
    }

    private void OnEnemyTurnEnd() {
        Debug.Log("enemy turn end!!!");
        foreach (Champion ally in HexGrid.Instance.GetAllyChamps()) {           // see above
            ally.NewTurnReset();
        }
        gameStateController.SetState(new SelectionState(gameStateController));
    }
}
