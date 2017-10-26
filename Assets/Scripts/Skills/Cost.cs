using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cost{

    public int amount;

	public Cost(int amount) {
        this.amount = amount;
    }

    public abstract void ApplyCost(Champion user);

    public abstract bool HasUserEnoughResources(Champion user);
}
