﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoBehaviour {

    public static InputHandler instance;

    private void Awake() {
        if(instance != null) {
            Debug.LogError("more than one input handler");
            return;
        }
        instance = this;
    }

    public event Action<SkillEnum> skillSelected;

	public void QButtonPressed() {
        RaiseEventSkillSelected(SkillEnum.Q);
    }

    public void WButtonPressed() {
        RaiseEventSkillSelected(SkillEnum.W);
    }

    public void EButtonPressed() {
        RaiseEventSkillSelected(SkillEnum.E);
    }

    public void RButtonPressed() {
        RaiseEventSkillSelected(SkillEnum.R);
    }

    private void Update() {
        //TODO: swap for custom keybinds eventually
        if (Input.GetKeyDown(KeyCode.Q)) { RaiseEventSkillSelected(SkillEnum.Q); }
        if (Input.GetKeyDown(KeyCode.W)) { RaiseEventSkillSelected(SkillEnum.W); }
        if (Input.GetKeyDown(KeyCode.E)) { RaiseEventSkillSelected(SkillEnum.E); }
        if (Input.GetKeyDown(KeyCode.R)) { RaiseEventSkillSelected(SkillEnum.R); }
    }

    private void RaiseEventSkillSelected(SkillEnum skillEnum) {
        if(skillSelected != null) { skillSelected(skillEnum); }
    }
}
