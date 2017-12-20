using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ManaCost : Cost {

    public ManaCost(int amount) : base(amount) {
    }

    public override void ApplyCost(ChampionStats userStats) {
        Debug.Log("apply cost called, cost: " + amount);
        userStats.Mana -= amount;
    }

    public override bool HasUserEnoughResources(Champion user) {
        return user.Stats.Mana >= amount;
    }
}
