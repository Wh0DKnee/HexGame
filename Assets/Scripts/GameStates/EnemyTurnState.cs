using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : GameState {

    public EnemyTurnState(GameStateController gsc) : base(gsc) {}

    public override void Tick() {
        //TODO: wait for server to signal that its our turn again and switch back to SelectAndMoveState
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        NetworkSession.instance.Client.TellServerTurnDone();
        NetworkSession.instance.Client.ClientProxy.EnemyTurnEnd += OnEnemyTurnEnd;
    }

    private void OnEnemyTurnEnd() {
        gameStateController.SetState(new SelectionState(gameStateController));
    }
}
