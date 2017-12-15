using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Cost{

    public int amount;

	public Cost(int amount) {
        this.amount = amount;
    }

    public abstract void ApplyCost(ChampionStats userStats);

    public abstract bool HasUserEnoughResources(Champion user);
}
