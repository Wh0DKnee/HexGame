using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cost{

    public int amount;
    public Champion champion;

	public Cost(int amount, Champion champion) {
        this.amount = amount;
        this.champion = champion;
    }

    public abstract void ApplyCost();
}
