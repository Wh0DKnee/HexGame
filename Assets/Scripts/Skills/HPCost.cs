using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HPCost : Cost {

    public HPCost(int amount) : base(amount) {
    }

    public override void ApplyCost(ChampionStats userStats) {
        userStats.HP -= amount;
    }

    public override bool HasUserEnoughResources(Champion user) {
        return user.Stats.HP >= amount;
    }
}
