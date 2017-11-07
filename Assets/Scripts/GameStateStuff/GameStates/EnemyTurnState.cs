using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : GameState {

    public EnemyTurnState(GameStateController gsc) : base(gsc) {}

    public override void Tick() {
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        NetworkSession.instance.Client.TellServerTurnDone();
        NetworkSession.instance.Client.ClientProxy.EnemyTurnEnd += OnEnemyTurnEnd;
    }

    private void OnEnemyTurnEnd() {
        foreach (Champion ally in HexGrid.Instance.GetAllyChamps()) {
            ally.NewTurnReset();
        }
        gameStateController.SetState(new SelectionState(gameStateController));
    }
}
