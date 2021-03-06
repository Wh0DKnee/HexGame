﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillState : CellListenerGameState {

    private Champion selectedChamp;

    public SkillState(GameStateController gsc, Champion selectedChamp) : base(gsc) {
        this.selectedChamp = selectedChamp;
    }

    public override void InitializeHighlightState() {
        if(selectedChamp.SelectedSkill == null) {
            stateHighlighter = new EmptyHighlighter(CellHighlighter.instance);
            return;
        }

        stateHighlighter = new SkillStateHighlighter(CellHighlighter.instance, selectedChamp, selectedChamp.SelectedSkill);
    }

    public override void OnStateEnter() {
        base.OnStateEnter();
        InputHandler.instance.skillSelected += OnSkillSelected;
    }

    public override void OnStateExit() {
        base.OnStateExit();
        InputHandler.instance.skillSelected -= OnSkillSelected;
    }

    private void OnSkillSelected(SkillEnum skillEnum) {
        Skill skill = selectedChamp.GetSkill(skillEnum);
        selectedChamp.SelectedSkill = skill;
        gameStateController.SetState(new SkillState(gameStateController, selectedChamp));
    }

    public override void Tick() {
        //TODO: move these events into InputHandler I think
        ReturnToSelectStateOnEscape();
        SkipUseSkillOnEnter();
    }

    public override void CellMouseDown(Cell clickedCell) {
        if(selectedChamp.SelectedSkill == null) {
            Debug.Log("No skill selected");
            return;
        }

        if (!selectedChamp.CanUseSkill(clickedCell)) {
            Debug.Log("Can't use spell on this cell");
            return;
        }

        gameStateController.SkillHandler.HandleSkill(selectedChamp.SelectedSkill, clickedCell.coordinates);
        StateChangeParams stateChangeParams = new StateChangeParams(gameStateController, selectedChamp);
        gameStateController.SetState(gameStateController.SkillHandler.GetNextState(stateChangeParams));
    }

    private void SkipUseSkillOnEnter() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            selectedChamp.SkipUseSkill();   //TODO: network this to show the other player that the attack was skipped
                                            // (easily done by creating a pseudo skill that does nothing and costs nothing, since skills are already synced)
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }

    private void ReturnToSelectStateOnEscape() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameStateController.SetState(new SelectionState(gameStateController));
        }
    }
}
