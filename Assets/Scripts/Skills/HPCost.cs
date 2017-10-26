using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCost : Cost {

    public HPCost(int amount) : base(amount) {
    }

    public override void ApplyCost(Champion user) {
        user.HP -= amount;
    }

    public override bool HasUserEnoughResources(Champion user) {
        return user.HP >= amount;
    }
}
