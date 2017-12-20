using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChampionUI : MonoBehaviour {

    public Canvas canvas;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI manaText;
    public Champion champion;

    private void Update() {
        canvas.transform.forward = champion.transform.forward;
    }

    public void Subscribe() {
        champion.Stats.hpChanged += OnHPChanged;
        champion.Stats.manaChanged += OnManaChanged;
    }

    public void OnManaChanged(int val) {
        manaText.text = val.ToString();
    }

    public void OnHPChanged(int val) {
        hpText.text = val.ToString();
    }

    private void OnDestroy() {
        champion.Stats.hpChanged -= OnHPChanged;
        champion.Stats.manaChanged -= OnManaChanged;
    }
}
